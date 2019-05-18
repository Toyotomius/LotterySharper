using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface IFindLottoTriplets
    {
        Task FindTripsAsync(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}