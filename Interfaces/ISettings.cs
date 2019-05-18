using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace LotteryCore.Interfaces
{
    public interface ISettings
    {
        Task<JObject> GetSettings();
    }
}