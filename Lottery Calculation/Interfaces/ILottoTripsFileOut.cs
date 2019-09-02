using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoTripsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}
