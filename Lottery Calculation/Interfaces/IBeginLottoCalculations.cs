using LotterySharper.LotteryCalculation.Properties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IBeginLottoCalculations
    {
        Task LottoChain(string lotteryName, List<LottoData> lotto);
    }
}
