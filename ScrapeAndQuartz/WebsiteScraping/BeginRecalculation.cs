using LotterySharper.LotteryCalculation.Interfaces;
using LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping
{
    public class BeginRecalculation : IBeginRecalculation
    {
        private readonly IValidateLottoLists _validateLottoList;

        /// <summary>
        ///     Uses validateLottoList to start the new frequency calculation for the just-scrapped lottery.
        /// </summary>
        /// <param name="validateLottoList"></param>
        public BeginRecalculation(IValidateLottoLists validateLottoList)
        {
            _validateLottoList = validateLottoList;
        }

        /// <summary>
        ///     Creates the tuple that the validator is looking for.
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <param name="lotteryJsonString">String in Json format from the lottery website scrape</param>
        public void PrepareNewCalcDataAsync(string lotteryName, string lotteryJsonString)
        {
            var lotteryFile = new List<string> { lotteryName };

            JObject lotteryJObject = JObject.Parse(lotteryJsonString);
            var jObjectList = new List<JObject> { lotteryJObject };
            (List<string> lotteryFile, List<JObject> lotteryJObject) lotteryInfo = (lotteryFile, jObjectList);

            _validateLottoList.ValidateLotteryLists(lotteryInfo);
        }
    }
}
