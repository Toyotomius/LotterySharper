using System.Collections.Generic;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoSinglesJsonSerial : ILottoSinglesJsonSerial
    {
        private IListJsonSerializer _serializer;

        private ILottoSinglesFileOut _singlesFileOut;

        public LottoSinglesJsonSerial(IListJsonSerializer serializer, ILottoSinglesFileOut singlesFileOut)
        {
            _serializer = serializer;
            _singlesFileOut = singlesFileOut;
        }

        public void SinglesSerialize(string lotteryName, List<Singles> singlesList)
        {
            string singlesJson = _serializer.JSerialize(singlesList);

            _singlesFileOut.WriteFile(lotteryName, singlesJson);
        }
    }
}