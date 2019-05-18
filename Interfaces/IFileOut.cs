using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface IFileOut
    {
        Task WriteFile(string lotteryName, string data);
    }
}