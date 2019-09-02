using LotterySharper.LotteryCalculation.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.BonusCode
{
    public class LottoBonusJsonSerial : ILottoBonusJsonSerial
    {
        private readonly ILottoBonusFileOut _bonusFileOut;
        private readonly IListJsonSerializer _serializer;

        public LottoBonusJsonSerial(IListJsonSerializer serializer, ILottoBonusFileOut bonusFileOut)
        {
            _serializer = serializer;
            _bonusFileOut = bonusFileOut;
        }

        public async Task BonusSerializeAsync(string lotteryName, IList<ISingles> bonusList)
        {
            string bonusJson = _serializer.JSerialize(bonusList);

            await _bonusFileOut.WriteFileAsync(lotteryName, bonusJson);
        }
    }
}
