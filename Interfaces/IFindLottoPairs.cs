using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface IFindLottoPairs
    {
        void FindPairs(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}