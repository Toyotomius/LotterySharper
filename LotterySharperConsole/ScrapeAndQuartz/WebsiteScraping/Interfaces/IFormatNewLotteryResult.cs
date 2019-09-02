using System.Threading.Tasks;

namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IFormatNewLotteryResult
    {
        Task<string> FormatResult(string winningNumbers, string bonusNumber);
    }
}
