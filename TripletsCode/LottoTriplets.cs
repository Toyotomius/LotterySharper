using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore.TripletsCode
{
    public class FindLottoTriplets : IFindLottoTriplets
    {
        private ILottoTripsJsonSerial _tripsJsonSerial;

        public FindLottoTriplets(ILottoTripsJsonSerial tripsJsonSerial)
        {
            _tripsJsonSerial = tripsJsonSerial;
        }

        public async Task FindTripsAsync(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Triplets Started");
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

            await _tripsJsonSerial.TripsSerializeAsync(lotteryName, tripletList);
        }
    }
}