using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;

namespace LotteryCore.Interfaces
{
    public interface ILottoTripsJsonSerial
    {
        Task TripsSerializeAsync(string lotteryName, List<Triplets> tripletList);
    }
}