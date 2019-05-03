using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace LotteryCore
{
    public class FileHandling
    {
        // TODO: Make this less method specific. I want it to do the thing based on what argument gets passed for singles, pairs, or trips.

        public void FileOut(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto)
        {
            LottoSingles lottoSingles = new LottoSingles();

            #region Singles

            string singleJsonPath = $"{lotteryName}Singles.json";

            // Creates new list and adds content from method for conversion to json
            List<Singles> s = new List<Singles>();
            foreach (var itm in lottoSingles.FindSingles(parsedLotto))
            {
                s.Add(new Singles
                {
                    First = itm.FirstNum,
                    Frequency = itm.Count
                });
            }

            // Converts list to json string.
            string singlesJson = JsonConvert.SerializeObject(s, Formatting.Indented);

            // Writes json string to file.
            using (StreamWriter sw = new StreamWriter(singleJsonPath))
            {
                sw.WriteLine(singlesJson);
            }

            #endregion Singles

            #region Pairs

            FindLottoPairs lottoPairs = new FindLottoPairs();
            NumberParsing freq = new NumberParsing();
            string pairJsonPath = $"{lotteryName}Pairs.json";

            List<Pairs> p = new List<Pairs>();

            // Instantiates frequency and processes the list only when needed immediately before building the object to
            // convert to json.

            foreach (var itm in lottoPairs.FindPairs(parsedLotto).ToList())
            {
                p.Add(new Pairs
                {
                    First = itm.Pair.FirstNum, // Order is Second, First, NumberParsing in output due to derived/base initialization order.
                    Second = itm.Pair.SecondNum,
                    Frequency = itm.Count
                });
            }

            string pairsJson = JsonConvert.SerializeObject(p, Formatting.Indented);

            // Picks out the last instance of a comma and removes it to adhere to json format.

            using (StreamWriter sw = new StreamWriter(pairJsonPath))
            {
                sw.WriteLine(pairsJson);
            }

            #endregion Pairs

            #region Triplets

            FindLottoTriplets lottoTrips = new FindLottoTriplets();
            string tripsJsonPath = $"{lotteryName}Trips.json";

            List<Triplets> t = new List<Triplets>();

            foreach (var itm in lottoTrips.FindTrips(parsedLotto).ToList())
            {
                t.Add(new Triplets
                {
                    First = itm.Triplet.FirstNum,
                    Second = itm.Triplet.SecondNum,
                    Third = itm.Triplet.ThirdNum,
                    Frequency = itm.Count
                });
            }

            string tripsJson = JsonConvert.SerializeObject(t, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(tripsJsonPath))
            {
                sw.WriteLine(tripsJson);
            }

            #endregion Triplets
        }
    }

    public class Singles
    {
        public int First { get; set; }

        public int Frequency { get; set; }
    }

    public class Pairs : Singles
    {
        public int Second { get; set; }
    }

    public class Triplets : Pairs
    {
        public int Third { get; set; }
    }
}

// TODOCompleted: Create Handling for any lottery set. Use config file to import the files instead of hard-code. Read
// root object and assign accordingly per lottery.
// TODOCompleted: Re-Write the file when called instead of perma-appending to a giant arse file.