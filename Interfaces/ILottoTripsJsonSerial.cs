using System.Collections.Generic;

using LotteryCore.GetSetObjects;

namespace LotteryCore.Interfaces
{
    public interface ILottoTripsJsonSerial
    {
        void TripsSerialize(string lotteryName, List<Triplets> tripletList);
    }
}