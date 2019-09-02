using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        Task SinglesSerializeAsync(string lotteryName, IList<ISingles> singlesList);
    }
}
