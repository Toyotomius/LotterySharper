using System.Collections.Generic;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoPairsJsonSerial : ILottoPairsJsonSerial
    {
        private IListJsonSerializer _serializer;

        private ILottoPairsFileOut _pairsFileOut;

        public LottoPairsJsonSerial(IListJsonSerializer serializer, ILottoPairsFileOut pairsFileOut)
        {
            _serializer = serializer;
            _pairsFileOut = pairsFileOut;
        }

        public void PairsSerialize(string lotteryName, List<Pairs> pairsList)
        {
            string pairsJson = _serializer.JSerialize(pairsList);

            _pairsFileOut.WriteFile(lotteryName, pairsJson);
        }
    }
}