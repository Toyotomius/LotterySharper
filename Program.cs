using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    internal class Program
    {
        private static void Main()
        {
            //SchdTask schd = new SchdTask();
            //schd.Schedule();
            //while (true)
            //{
            //}
            string logFile = Settings.LogFile;

            //WebsiteScraping ws = new WebsiteScraping();
            //ws.Scrape();

            //Console.ReadKey();

            // Temporarily commented out while working on other classes & methods.
            while (true)
            {
                Settings settings = new Settings();

                // Retrieves the filename and the list of Json objects from the files as a tuple.
                (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = settings.ApplySettings();
                var lotteryFile = lotteryInfo.LotteryFile;

                //TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
                // TODO: Clean up logfile at various points.
                
                // Iterates through confirmed file data and 
                for (var i = 0; i < lotteryInfo.LotteryJObject.Count; i++)
                {
                    var lotteryName = $"{Path.GetFileNameWithoutExtension(lotteryInfo.LotteryFile[i].ToString())}";
                    var lotteryData = lotteryInfo.LotteryJObject[i];
                    FileHandling fh = new FileHandling();
                    List<FileHandling.LottoData> lotto;

                    try
                    {
                        lotto = fh.CreateLottoList(lotteryName, lotteryData);
                    }
                    catch (ArgumentNullException)
                    {
                        using (StreamWriter sw = new StreamWriter(logFile, append: true))
                        {
                            sw.WriteLine(
                                $"{DateTime.Now} : Lottery Data List creation failed for \"{lotteryFile[i]}\". Verify the json file is correctly formed." +
                                "\nSee example.json for correct format. Ensure root object & file name are identical.");
                        }

                        continue;
                    }

                    fh.FileOut(lotteryName, lotto);
                }

                Console.WriteLine("Breakpoint");

                Console.WriteLine("Done");

                //    System.Threading.Thread.Sleep(30000);
                //}
            }
        }
    }
}

//TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
//TODO: Add some sort of ability to pick out frequency based on a range of dates.
//TODOCompleted: Set up a while:true as a test with a decent sleep for on-the-fly settings change with a new lotto file.