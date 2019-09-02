using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IParaTriplets
    {
        void FindTripsParallel(string lotteryName,
                               (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto);
    }
}
