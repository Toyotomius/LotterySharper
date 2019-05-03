﻿using System;
using System.Collections.Generic;
using System.Linq;
using LotteryCore.GetSetObjects;

namespace LotteryCore
{
    internal class LottoPairs
    {
        public int FirstNum { get; set; }

        public int SecondNum { get; set; }
    }

    public class FindLottoPairs
    {
        public IEnumerable<LottoPairsCount> FindPairs((IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            List<LottoPairs> pairs = (
                from firstNum in parsedLotto.DistinctNumbers
                from secondNum in parsedLotto.DistinctNumbers

                    // Grabs a number and compares it to a second number to ensure they're not the same number.
                where firstNum.CompareTo(secondNum) < 0

                // Picks out all the potential number combinations and tosses it back to a pair list.
                select new LottoPairs { FirstNum = firstNum, SecondNum = secondNum }).ToList();

            IEnumerable<LottoPairsCount> pairList =
                    (from l in parsedLotto.AllNumbers
                     from p in pairs

                         // Grabs each possible pair and the entire list of number arrays and finds where both numbers
                         // appear in each array for each number pair.
                     where l.Contains(p.FirstNum) && l.Contains(p.SecondNum)
                     group l by p into g
                     orderby g.Count() descending // Orders each pair combination found by descending frequency count.
                     select new LottoPairsCount
                     {
                         Pair = g.Key,
                         Count = g.Count()
                     }); // Grabs each pair as a key and each count -- could list it here but if kept iEnumerable will only process when it's needed.

            // Don't know effect if more than one thing needs it. Does it do it every time where a list would be faster?

            return pairList;
        }
    }
}