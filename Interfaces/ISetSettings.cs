using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace LotteryCore.Interfaces
{
    public interface ISetSettings
    {
        (List<string> LotteryFile, List<JObject> LotteryJObject) ApplySettings();
    }
}