using System.Collections.Generic;
using System.Linq;
using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class NumberParsing : INumberParsing
    {

        public IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        public IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        public (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) ParseLottoList(List<ILottoData> lotto)
        {
            AllNumbers = lotto.Select(a => a.Numbers);
            DistinctNumbers = lotto.SelectMany(a => a.Numbers).Distinct();
            return (AllNumbers, DistinctNumbers);
        }

        //TODOCompleted Optimization. Review later.

        

        

        public IEnumerable<LottoPairsCount> FindPairs((IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            List<LottoPairs> pairs = (
                from firstNum in parsedLotto.DistinctNumbers
                from secondNum in parsedLotto.DistinctNumbers

                    // Grabs a number and compares it to a second number to ensure they're not the same number.
                where firstNum.CompareTo(secondNum) < 0

                // Picks out all the potential number combinations and tosses it back to a pair list.
                select new LottoPairs { FirstNum = firstNum, SecondNum = secondNum }).ToList();

            IEnumerable<LottoPairsCount> pairList =
                (from l in parsedLotto.AllNumbers
                 from p in pairs

                     // Grabs each possible pair and the entire list of number arrays and finds where both numbers appear
                     // in each array for each number pair.
                 where l.Contains(p.FirstNum) && l.Contains(p.SecondNum)
                 group l by p into g
                 orderby g.Count() descending // Orders each pair combination found by descending frequency count.
                 select new LottoPairsCount
                 {
                     Pair = g.Key,
                     Count = g.Count()
                 }); // Grabs each pair as a key and each count -- could list it here but if kept iEnumerable will only process when it's needed.

            // Don't know effect if more than one thing needs it. Does it do it every time where a list would be faster?

            return pairList;
        }

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

    public class LottoSinglesCount
    {
        internal int FirstNum { get; set; }

        internal int Count { get; set; }
    }
    internal class LottoPairs
    {
        public int FirstNum { get; set; }

        public int SecondNum { get; set; }
    }
    public class LottoPairsCount
    {
        internal LottoPairs Pair { get; set; }

        internal int Count { get; set; }
    }
    public class LottoTripletsCount
    {
        internal LottoTriplets Triplet { get; set; }

        internal int Count { get; set; }
    }

    internal class LottoTriplets : LottoPairs
    {
        public int ThirdNum { get; set; }
    }

    
}

// TODO: Calculate bonus frequency separately.