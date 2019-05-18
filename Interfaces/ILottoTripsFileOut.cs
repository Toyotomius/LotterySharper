using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface ILottoTripsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}