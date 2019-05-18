using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface ILottoPairsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}