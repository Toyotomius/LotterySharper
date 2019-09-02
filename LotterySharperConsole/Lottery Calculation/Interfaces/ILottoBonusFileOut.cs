using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoBonusFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}
