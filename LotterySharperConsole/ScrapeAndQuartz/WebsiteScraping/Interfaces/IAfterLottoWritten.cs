namespace LotterySharper.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IAfterLottoWritten
    {
        void OnResultsWritten(object source, LottoEventArgs e);
    }
}
