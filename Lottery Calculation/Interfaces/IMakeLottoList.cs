using LotterySharper.LotteryCalculation.Properties;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IMakeLottoList
    {
        List<LottoData> CreateLottoList(string lotteryName, JObject lotteryData);
    }
}
