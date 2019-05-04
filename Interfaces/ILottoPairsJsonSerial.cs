using System.Collections.Generic;

using LotteryCore.GetSetObjects;

namespace LotteryCore.Interfaces
{
    public interface ILottoPairsJsonSerial
    {
        void PairsSerialize(string lotteryName, List<Pairs> pairsList);
    }
}