using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoBonusJsonSerial
    {
        Task BonusSerializeAsync(string lotteryName, IList<ISingles> bonusList);
    }
}
