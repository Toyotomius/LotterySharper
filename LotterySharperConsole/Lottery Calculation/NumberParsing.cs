using LotterySharper.LotteryCalculation.Interfaces;
using LotterySharper.LotteryCalculation.Properties;
using System.Collections.Generic;
using System.Linq;

namespace LotterySharper.LotteryCalculation
{
    public class NumberParsing : INumberParsing
    {
        public (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> Bonus) ParseLottoList(List<LottoData> lotto)
        {
            (IEnumerable<int[]>, IEnumerable<int>, IEnumerable<int>) results = (AllNumbers =
                lotto.Select(a => a.Numbers),
                DistinctNumbers = lotto.SelectMany(a => a.Numbers).Distinct(),
                BonusNumbers = lotto.Select(a => a.Bonus));

            return results;
        }

        public IEnumerable<int[]> AllNumbers
        {
            get;
            set;
        }

        public IEnumerable<int> BonusNumbers { get; set; }

        // Selects all the number arrays from the list.
        public IEnumerable<int> DistinctNumbers
        {
            get;
            set;
        }

        // Grabs just the distinct numbers in the list.

        //TODOCompleted Optimization. Review later.
    }
}

// TODO: Calculate bonus frequency separately.
