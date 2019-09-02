using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IFileOut
    {
        Task WriteFile(string lotteryName, string data);
    }
}
