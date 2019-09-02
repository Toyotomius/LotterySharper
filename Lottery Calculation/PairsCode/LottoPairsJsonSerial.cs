using LotterySharper.LotteryCalculation.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.PairsCode
{
    public class LottoPairsJsonSerial : ILottoPairsJsonSerial
    {
        private readonly ILottoPairsFileOut _pairsFileOut;
        private readonly IListJsonSerializer _serializer;

        public LottoPairsJsonSerial(IListJsonSerializer serializer, ILottoPairsFileOut pairsFileOut)
        {
            _serializer = serializer;
            _pairsFileOut = pairsFileOut;
        }

        public async Task PairsSerializeAsync(string lotteryName, IList<IPairs> pairsList)
        {
            string pairsJson = _serializer.JSerialize(pairsList);

            await _pairsFileOut.WriteFileAsync(lotteryName, pairsJson);
        }
    }
}
