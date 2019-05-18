using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface IFindLottoSingles
    {
        Task FindSinglesAsync(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}