using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface ILottoSingles
    {
        void FindSingles(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}