using System.Threading.Tasks;

namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IUserAgentPicker
    {
        Task<string> RandomUserAgentAsync();
    }
}
