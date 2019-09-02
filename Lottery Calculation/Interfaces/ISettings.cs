using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ISettings
    {
        Task<JObject> ReadSettings();
    }
}
