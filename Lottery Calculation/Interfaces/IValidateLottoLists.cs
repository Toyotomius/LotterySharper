using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IValidateLottoLists
    {
        Task ValidateLotteryLists((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo);
    }
}
