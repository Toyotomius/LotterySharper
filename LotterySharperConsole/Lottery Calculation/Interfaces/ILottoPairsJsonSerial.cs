using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoPairsJsonSerial
    {
        Task PairsSerializeAsync(string lotteryName, IList<IPairs> pairsList);
    }
}
