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