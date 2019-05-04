using System.Collections.Generic;
using System.Linq;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoSingles : ILottoSingles
    {
        private ILottoSinglesJsonSerial _singlesJsonSerial;

        public LottoSingles(ILottoSinglesJsonSerial singlesJsonSerial)
        {
            _singlesJsonSerial = singlesJsonSerial;
        }

        public void FindSingles(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            List<Singles> singlesList = (from n in parsedLotto.AllNumbers.SelectMany(x => x)
                                         group n by n into g
                                         orderby g.Count() descending
                                         select new Singles { First = g.Key, Frequency = g.Count() }).ToList();

            _singlesJsonSerial.SinglesSerialize(lotteryName, singlesList);
        }
    }
}