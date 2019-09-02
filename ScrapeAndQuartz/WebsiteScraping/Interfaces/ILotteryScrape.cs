using System.Threading.Tasks;

namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface ILotteryScrape
    {
        Task ScrapeLotteryAsync();
    }
}
