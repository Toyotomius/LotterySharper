using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface IFindLottoTriplets
    {
        void FindTrips(string lotteryName,
            (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}