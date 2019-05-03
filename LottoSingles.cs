using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoSingles
    {
        public IEnumerable<LottoSinglesCount> FindSingles((IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            
            
            List<LottoSinglesCount> singlesList = (from n in parsedLotto.AllNumbers.SelectMany(x => x)
                group n by n into g
                orderby g.Count() descending
                select new LottoSinglesCount { FirstNum = g.Key, Count = g.Count() }).ToList();
            return singlesList;
        }
    }
}
