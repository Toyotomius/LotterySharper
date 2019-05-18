using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface ILottoSinglesFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}