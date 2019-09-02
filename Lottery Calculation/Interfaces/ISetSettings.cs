using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ISetSettings
    {
        Task<(List<string> LotteryFile, List<JObject> LotteryJObject, bool scrapeWebsites)> ApplySettingsAsync();
    }
}
