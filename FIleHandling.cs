using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class FileHandling
    {
        private List<LottoData> _lottoData = new List<LottoData>();

        private string _output;

        public List<LottoData> CreateLottoList()
        {
            JObject lotteryObject = Program.LotteryJObject;

            //TODO: Find a better way of doing this.

            for (int i = 0; i < lotteryObject[Program.LotteryName].Count(); i++)
            {
                _lottoData.Add(new LottoData
                {
                    Date = lotteryObject[Program.LotteryName][i]["Date"].ToString(),
                    Numbers = lotteryObject[Program.LotteryName][i]["Numbers"].Select(x => (int)x).ToArray()
                });
            }

            return _lottoData;
        }

        // TODO: Make this less method specific. I want it to do the thing based on what argument gets passed for singles, pairs, or trips.

        public void FileOut(List<LottoData> lotto)
        {
            Frequency freq = new Frequency(lotto);

            #region Start Singles

            StringBuilder sb = new StringBuilder();

            string singleJsonPath = $"{Program.LotteryName}Singles.json";
            File.Delete(singleJsonPath);

            sb.AppendLine($"{{\"{Program.LotteryName}Singles\" : \n[");

            foreach (var t in freq.FindSingles())
            {
                sb.AppendLine($@"{{""Number"": {t.Number}, ""Frequency"": {t.Count}}},");
            }
            var index = sb.ToString().LastIndexOf(',');

            if (index >= 0)
            {
                sb.Remove(index, 1);
            }
            sb.AppendLine("]\n}");
            _output = sb.ToString();

            using (StreamWriter sw = new StreamWriter(singleJsonPath, append: true))
            {
                sw.WriteLine(_output);
            }

            #endregion Start Singles

            #region Start Pairs

            sb.Clear();

            string pairJsonPath = $"{Program.LotteryName}Pairs.json";
            File.Delete(pairJsonPath);

            sb.AppendLine($"{{\"{Program.LotteryName}Pairs\" : \n[");

            // Instantiates frequency and processes the list only when needed immediately before building the string to write.

            foreach (var t in freq.FindPairs().ToList())
            {
                sb.AppendLine($@"{{""First"": {t.Pair.FirstNum}, ""Second"": {t.Pair.SecondNum}, ""Frequency"": {t.Count}}},");
            }

            // Picks out the last instance of a comma and removes it to adhere to json format.
            index = sb.ToString().LastIndexOf(',');
            if (index >= 0)
            {
                sb.Remove(index, 1);
            }

            sb.AppendLine("]\n}");

            _output = sb.ToString();

            using (StreamWriter sw = new StreamWriter(pairJsonPath, append: true))
            {
                sw.WriteLine(_output);
            }

            #endregion Start Pairs



            #region Start Triplets
            sb.Clear();
            string tripsJsonPath = $"{Program.LotteryName}Trips.json";
            File.Delete(tripsJsonPath);
            sb.AppendLine($"{{\"{Program.LotteryName}Triplets\" : \n[");

            foreach (var t in freq.FindTrips().ToList())
            {
                sb.AppendLine($@"{{""First"": {t.Triplet.FirstNum}, ""Second"": {t.Triplet.SecondNum}, ""Third"": {t.Triplet.ThirdNum}, ""Frequency"": {t.Count}}},");
            }

            index = sb.ToString().LastIndexOf(',');
            if (index >= 0)
            {
                sb.Remove(index, 1);
            }

            sb.AppendLine("]\n}");

            _output = sb.ToString();

            using (StreamWriter sw = new StreamWriter(tripsJsonPath, append: true))
            {
                sw.WriteLine(_output);
            }

            #endregion Start Triplets
        }

        public class LottoData
        {
            public string Date { get; set; }

            public int[] Numbers { get; set; }
        }
    }
}

// TODOCompleted: Create Handling for any lottery set. Use config file to import the files instead of hard-code. Read
//                root object and assign accordingly per lottery.
// TODOCompleted: Re-Write the file when called instead of perma-appending to a giant arse file.