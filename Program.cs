using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    internal class Program
    {
        public static JObject LotteryJObject;

        private static string _lotteryFile;

        private static string _lotteryName;

        public static string LotteryName
        {
            get => _lotteryName;
            private set => _lotteryName = value;
        }

        private static void Main()
        {
            string logFile = "logfile.txt";

            WebsiteScraping ws = new WebsiteScraping();
            ws.Scrape();

            Console.ReadKey();

            //Temporarily commented out while working on other classes & methods.
            //while (true)
            //{
            //    Settings settings = new Settings();
            //    settings.GetSettings();

            //    //TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            //    // TODO: Clean up logfile at various points.

            //    foreach (JToken itm in (JArray)settings.SettingsFromFile["LotteryMasterFiles"])
            //    {
            //        _lotteryFile = itm.ToString();

            //        try
            //        {
            //            LotteryJObject = JObject.Parse(File.ReadAllText($"{_lotteryFile}"));
            //        }
            //        catch (Exception) when (!File.Exists(_lotteryFile))
            //        {
            //            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            //            {
            //                sw.WriteLine($"{DateTime.Now} : " +
            //                             $"File \"{_lotteryFile}\" Does Not Exist. Verify the folder location & is correctly named in the config.\n" +
            //                             $"    * Check the config.json file for proper format.");
            //            }
            //            continue;
            //        }

            //        LotteryName = $"{Path.GetFileNameWithoutExtension(_lotteryFile)}";
            //        FileHandling fh = new FileHandling();
            //        List<FileHandling.LottoData> lotto;

            //        try
            //        {
            //            lotto = fh.CreateLottoList();
            //        }
            //        catch (ArgumentNullException)
            //        {
            //            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            //            {
            //                sw.WriteLine(
            //                    $"{DateTime.Now} : Lottery Data List creation failed for \"{_lotteryFile}\". Verify the json file is correctly formed." +
            //                    "\nSee example.json for correct format. Ensure root object & file name are identical.");
            //            }
            //            continue;
            //        }


            //        fh.FileOut(lotto);

            //    }

            //Console.WriteLine("Breakpoint");

            //    Console.WriteLine("Done");

            //    System.Threading.Thread.Sleep(30000);
            //}

        }
    }
}

//TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
//TODO: Add some sort of ability to pick out frequency based on a range of dates.
//TODOCompleted: Set up a while:true as a test with a decent sleep for on-the-fly settings change with a new lotto file.