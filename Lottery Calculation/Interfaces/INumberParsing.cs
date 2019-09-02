using LotterySharper.LotteryCalculation.Properties;
using System.Collections.Generic;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface INumberParsing
    {
        (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> Bonus) ParseLottoList(List<LottoData> lotto);

        IEnumerable<int[]> AllNumbers
        {
            get;
            set;
        }

        IEnumerable<int> BonusNumbers { get; set; }

        // Selects all the number arrays from the list.
        IEnumerable<int> DistinctNumbers
        {
            get;
            set;
        }

        // Grabs just the distinct numbers in the list.
    }
}
