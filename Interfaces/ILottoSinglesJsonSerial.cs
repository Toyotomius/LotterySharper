using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        void SinglesSerialize(string lotteryName, List<Singles> singlesList);
    }
}