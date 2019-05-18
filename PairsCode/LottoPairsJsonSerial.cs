using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore.PairsCode
{
    public class LottoPairsJsonSerial : ILottoPairsJsonSerial
    {
        private ILottoPairsFileOut _pairsFileOut;
        private IListJsonSerializer _serializer;

        public LottoPairsJsonSerial(IListJsonSerializer serializer, ILottoPairsFileOut pairsFileOut)
        {
            _serializer = serializer;
            _pairsFileOut = pairsFileOut;
        }

        public async Task PairsSerializeAsync(string lotteryName, List<Pairs> pairsList)
        {
            string pairsJson = _serializer.JSerialize(pairsList);

            await _pairsFileOut.WriteFileAsync(lotteryName, pairsJson);
        }
    }
}