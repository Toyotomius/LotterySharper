using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IGetSettings
    {
        Task<(List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites)> RetrieveSettings();
    }
}
