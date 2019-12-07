using LotterySharper.LotteryCalculation.Interfaces;
using LotterySharper.LotteryCalculation.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation
{
    public class ValidateLottoLists : IValidateLottoLists
    {
        private readonly IBeginLottoCalculations _beginCalculations;

        public ValidateLottoLists(IBeginLottoCalculations beginCalculations)
        {
            _beginCalculations = beginCalculations;
        }

        public async Task ValidateLotteryLists((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo)
        {
            ILogging log = Factory.CreateLogger();
            var parallelLog = new ConcurrentBag<string>();
            var lotto = new List<LottoData>();
            Task<ParallelLoopResult> task = Task.Run(() => Parallel.ForEach(lotteryInfo.LotteryJObject,
                                                                            currentObject =>
            {
                int i = lotteryInfo.LotteryJObject.IndexOf(currentObject);
                string lotteryName = $"{Path.GetFileNameWithoutExtension(lotteryInfo.LotteryFile[i])}";
                JObject lotteryData = lotteryInfo.LotteryJObject[i];
                IMakeLottoList createLottoList = Factory.CreateLottoList();

                try
                {
                    lotto = createLottoList.CreateLottoList(lotteryName, lotteryData);
                }
                catch (ArgumentNullException)
                {
                    parallelLog.Add($"{DateTime.Now} : Lottery Data List creation failed for \"{lotteryInfo.LotteryFile[i]}\". Verify the json file is correctly formed.\n" +
                        "    * See example.json for correct format. Ensure root object & file name are identical.");
                }

                _beginCalculations.LottoChain(lotteryName, lotto);
            }));
            log.Log(string.Join(Environment.NewLine, parallelLog));
            await task;
        }
    }
}
