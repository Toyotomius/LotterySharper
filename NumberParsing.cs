using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class NumberParsing : INumberParsing
    {
        public IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        public IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        public async Task<(IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers)> ParseLottoListAsync(List<ILottoData> lotto)
        {
            Task<(IEnumerable<int[]>, IEnumerable<int>)> task = Task.FromResult((AllNumbers = lotto.Select(a => a.Numbers),
                DistinctNumbers = lotto.SelectMany(a => a.Numbers).Distinct()));

            var results = await task;
            return (results);
        }

        //TODOCompleted Optimization. Review later.
    }
}

// TODO: Calculate bonus frequency separately.