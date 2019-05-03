using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface INumberParsing
    {
        IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) ParseLottoList(List<ILottoData> lotto);
    }
}