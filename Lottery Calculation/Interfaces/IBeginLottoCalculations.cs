using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IBeginLottoCalculations
    {
        Task LottoChain(string lotteryName, List<LottoData> lotto);
    }
}