using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface IFindLottoPairs
    {
        Task FindPairsAsync(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}