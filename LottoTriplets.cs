using System.Collections.Generic;
using System.Linq;

namespace LotteryCore
{
    public class FindLottoTriplets
    {
        public IEnumerable<LottoTripletsCount> FindTrips((IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            List<LottoTriplets> trips =
                (from firstNum in parsedLotto.DistinctNumbers
                 from secondNum in parsedLotto.DistinctNumbers
                 from thirdNum in parsedLotto.DistinctNumbers
                 where firstNum.CompareTo(secondNum) < 0 && firstNum.CompareTo(thirdNum) < 0 && secondNum.CompareTo(thirdNum) < 0
                 select new LottoTriplets { FirstNum = firstNum, SecondNum = secondNum, ThirdNum = thirdNum }).ToList();

            IEnumerable<LottoTripletsCount> tripletList =
                (from l in parsedLotto.AllNumbers
                 from p in trips
                 where l.Contains(p.FirstNum) && l.Contains(p.SecondNum) && l.Contains(p.ThirdNum)
                 group l by p into g
                 orderby g.Count() descending
                 select new LottoTripletsCount
                 {
                     Triplet = g.Key,
                     Count = g.Count()
                 });

            return tripletList;
        }
    }
}