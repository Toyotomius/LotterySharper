using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoPairsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}
