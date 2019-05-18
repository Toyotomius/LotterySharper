using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;

namespace LotteryCore.Interfaces
{
    public interface ILottoPairsJsonSerial
    {
        Task PairsSerializeAsync(string lotteryName, List<Pairs> pairsList);
    }
}