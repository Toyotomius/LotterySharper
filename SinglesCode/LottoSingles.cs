using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore.SinglesCode
{
    public class LottoSingles : IFindLottoSingles
    {
        private ILottoSinglesJsonSerial _singlesJsonSerial;

        public LottoSingles(ILottoSinglesJsonSerial singlesJsonSerial)
        {
            _singlesJsonSerial = singlesJsonSerial;
        }

        public async Task FindSinglesAsync(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Singles Started");
            List<Singles> singlesList = (from n in parsedLotto.AllNumbers.SelectMany(x => x)
                                         group n by n into g
                                         orderby g.Count() descending
                                         select new GetSetObjects.Singles { First = g.Key, Frequency = g.Count() }).ToList();

            await _singlesJsonSerial.SinglesSerializeAsync(lotteryName, singlesList);
        }
    }
}