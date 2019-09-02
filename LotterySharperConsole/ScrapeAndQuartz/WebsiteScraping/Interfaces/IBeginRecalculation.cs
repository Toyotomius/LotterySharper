namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IBeginRecalculation
    {
        void PrepareNewCalcDataAsync(string lotteryName, string lotteryJsonString);
    }
}
