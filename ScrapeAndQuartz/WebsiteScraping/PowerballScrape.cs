using LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping
{
    /// <summary>
    ///     Scrapes the Atlantic Lottery Corporation Website @ https://powerball.com/api/v1/numbers/powerball/recent?_format=json for the
    ///     winning Powerball numbers. Draws every Wed and Sat.
    /// </summary>
    public class PowerballScrape : ILotteryScrape
    {
        private readonly IAfterLottoWritten _afterLottoWritten;
        private readonly IFormatNewLotteryResult _formatNewLotteryResult;

        private readonly IWriteNewLottoResult _writeNewResult;

        /// <summary>
        ///     FormatNewLottery and WriteNewLottoResults to
        ///     handle the information returned from the scrape.
        /// </summary>
        /// <param name="websiteScraping"></param>
        /// <param name="formatNewLotteryResult"></param>
        /// <param name="writeNewLottoResult"></param>
        public PowerballScrape(IFormatNewLotteryResult formatNewLotteryResult,
                               IWriteNewLottoResult writeNewLottoResult,
                               IAfterLottoWritten afterLottoWritten)
        {
            _formatNewLotteryResult = formatNewLotteryResult;
            _writeNewResult = writeNewLottoResult;
            _afterLottoWritten = afterLottoWritten;
        }

        /// <summary>
        ///     Scrapes the winning results for Lotto649 with help from base class.
        /// </summary>
        /// <returns></returns>
        public async Task ScrapeLotteryAsync()
        {
            var lotteryUrl = "https://powerball.com/api/v1/numbers/powerball/recent?_format=json";
            string powerballJson;
            using (var client = new HttpClient())
            {
                powerballJson = await client.GetStringAsync(lotteryUrl);
            }

            JArray powerballData = JArray.Parse(powerballJson);
            var newLottoNumList = new List<string>();

            // Create a temporary list to store the lottery numbers.
            string[] tempList = powerballData[0]["field_winning_numbers"].ToObject<string>().Split(',');

            // Temporary list is then used to remove any leading 0s the website may have used. Json doesn't like leading 0s on numbers (fuck 'im).
            // Also removes the last number (bonus number) and separates it out into a new variable.

            foreach (string itm in tempList)
            {
                string newItm = itm.Replace(itm, itm.TrimStart(new[] { '0' }));
                newLottoNumList.Add(newItm);
            }
            string bonusNum = newLottoNumList.Last();
            newLottoNumList.Remove(bonusNum);

            string usPowerballNums = string.Join(", ", newLottoNumList);

            string newResults = await _formatNewLotteryResult.FormatResult(usPowerballNums, bonusNum);

            _writeNewResult.NewLotteryResultsWritten += _afterLottoWritten.OnResultsWritten;
            Task writeTask = Task.Run(() => _writeNewResult.WriteNewResults("USPowerball", newResults));
            await writeTask;
        }
    }
}

// TODO: Sanity checks.
