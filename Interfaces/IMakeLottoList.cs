using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace LotteryCore.Interfaces
{
    public interface IMakeLottoList
    {
        List<ILottoData> CreateLottoList(string lotteryName, JObject lotteryData);
    }
}