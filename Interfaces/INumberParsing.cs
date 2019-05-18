using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCore.Interfaces
{
    public interface INumberParsing
    {
        IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        Task<(IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers)> ParseLottoListAsync(List<ILottoData> lotto);
    }
}