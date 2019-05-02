using Newtonsoft.Json.Linq;

namespace LotteryCore.Interfaces
{
    public interface ISettings
    {
        JObject GetSettings();
    }
}