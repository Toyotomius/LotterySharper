using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoSinglesFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}
