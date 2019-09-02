using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IParaBonus
    {
        void FindBonusParallel(string lotteryName,
                               (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto);
    }
}
