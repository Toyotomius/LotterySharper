using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

namespace LotteryCore.SinglesCode
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

        public async Task SinglesSerializeAsync(string lotteryName, List<GetSetObjects.Singles> singlesList)
        {
            string singlesJson = _serializer.JSerialize(singlesList);

            await _singlesFileOut.WriteFileAsync(lotteryName, singlesJson);
        }
    }
}