using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IParaPairs
    {
        void FindPairsParallel(string lotteryName,
                               (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto);
    }
}
