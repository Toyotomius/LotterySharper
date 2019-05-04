using System.Collections.Generic;
using System.Linq;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class FindLottoTriplets : IFindLottoTriplets
    {
        private ILottoTripsJsonSerial _tripsJsonSerial;

        public FindLottoTriplets(ILottoTripsJsonSerial tripsJsonSerial)
        {
            _tripsJsonSerial = tripsJsonSerial;
        }

        public void FindTrips(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            List<Triplets> trips =
                (from firstNum in parsedLotto.DistinctNumbers
                 from secondNum in parsedLotto.DistinctNumbers
                 from thirdNum in parsedLotto.DistinctNumbers
                 where firstNum.CompareTo(secondNum) < 0 && firstNum.CompareTo(thirdNum) < 0 && secondNum.CompareTo(thirdNum) < 0
                 select new Triplets { First = firstNum, Second = secondNum, Third = thirdNum }).ToList();

            List<Triplets> tripletList =
                (from l in parsedLotto.AllNumbers
                 from p in trips
                 where l.Contains(p.First) && l.Contains(p.Second) && l.Contains(p.Third)
                 group l by p into g
                 orderby g.Count() descending
                 select new Triplets
                 {
                     First = g.Key.First,
                     Second = g.Key.Second,
                     Third = g.Key.Third,
                     Frequency = g.Count()
                 }).ToList();

            _tripsJsonSerial.TripsSerialize(lotteryName, tripletList);
        }
    }
}