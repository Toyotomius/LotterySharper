using System.Collections.Generic;

using LotteryCore.Interfaces;

using Newtonsoft.Json;

namespace LotteryCore
{
    public class ListJsonSerializer : IListJsonSerializer
    {
        public string JSerialize<T>(List<T> lottoList)
        {
            string frequencyJson = JsonConvert.SerializeObject(lottoList, Formatting.Indented);
            return frequencyJson;
        }
    }
}