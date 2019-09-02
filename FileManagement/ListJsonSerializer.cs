using LotterySharper.LotteryCalculation.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LotterySharper.FileManagement
{
    public class ListJsonSerializer : IListJsonSerializer
    {
        public string JSerialize<T>(IList<T> lottoList)
        {
            string frequencyJson = JsonConvert.SerializeObject(lottoList, Formatting.Indented);
            return frequencyJson;
        }
    }
}
