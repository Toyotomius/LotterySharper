using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class BeginLottoCalculations : IBeginLottoCalculations
    {
        private INumberParsing _lottoNumberParser;

        private IFindLottoPairs _startPairsChain;
        private IFindLottoSingles _startSinglesChain;
        private IFindLottoTriplets _startTripletsChain;

        public BeginLottoCalculations(INumberParsing lottoNumberParser, IFindLottoSingles startSinglesChain,
            IFindLottoPairs startPairsChain, IFindLottoTriplets startTripletsChain)
        {
            _lottoNumberParser = lottoNumberParser;
            _startSinglesChain = startSinglesChain;
            _startPairsChain = startPairsChain;
            _startTripletsChain = startTripletsChain;
        }

        public async Task StartLottoListsAsync()
        {
            while (true)
            {
                ISetSettings settings = Factory.SetNewSettings();
                ILogging log = Factory.CreateLogger();

                // Retrieves the filename and the list of Json objects from the files as a tuple.
                (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = await settings.ApplySettingsAsync();
                List<string> lotteryFile = lotteryInfo.LotteryFile;

                // TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
                // TODO: Clean up logfile at various points.

                // Iterates through confirmed file data and
                for (var i = 0; i < lotteryInfo.LotteryJObject.Count; i++)
                {
                    string lotteryName = $"{Path.GetFileNameWithoutExtension(lotteryInfo.LotteryFile[i])}";
                    JObject lotteryData = lotteryInfo.LotteryJObject[i];
                    IMakeLottoList createLottoList = Factory.CreateLottoList();
                    List<ILottoData> lotto;

                    try
                    {
                        lotto = createLottoList.CreateLottoList(lotteryName, lotteryData);
                    }
                    catch (ArgumentNullException)
                    {
                        log.Log(
                            $"{DateTime.Now} : Lottery Data List creation failed for \"{lotteryFile[i]}\". Verify the json file is correctly formed." +
                            "\nSee example.json for correct format. Ensure root object & file name are identical.");
                        continue;
                    }

                    var parsedLotto = await _lottoNumberParser.ParseLottoListAsync(lotto);

                    await Task.WhenAll(
                        _startSinglesChain.FindSinglesAsync(lotteryName, parsedLotto),
                       _startPairsChain.FindPairsAsync(lotteryName, parsedLotto),
                       _startTripletsChain.FindTripsAsync(lotteryName, parsedLotto)
                    );
                    //_startSinglesChain.FindSinglesAsync(lotteryName, parsedLotto);
                    //_startPairsChain.FindPairsAsync(lotteryName, parsedLotto);
                    //await _startTripletsChain.FindTripsAsync(lotteryName, parsedLotto);
                }
                Console.WriteLine("Breakpoint");

                Console.WriteLine("Done");
            }
        }
    }
}