using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface IListJsonSerializer
    {
        string JSerialize<T>(IList<T> lottoList);
    }
}
