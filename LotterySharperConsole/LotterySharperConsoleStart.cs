using LotterySharper.LotteryCalculation.Interfaces;
using LotterySharper.ScrapeAndQuartz.QuartzScheduling.Lotto649;
using LotterySharper.ScrapeAndQuartz.QuartzScheduling.LottoMax;
using LotterySharper.ScrapeAndQuartz.QuartzScheduling.USPowerball;
using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace LotterySharper
{
    internal static class LotterySharperConsoleStart
    {
        private static async Task Main()
        {
            IGetSettings set = Factory.CreateGetSettings();
            (List<string> lotteryFile, List<JObject> lotteryJObject, var scrapeWebsites) =
                await set.RetrieveSettings();
            (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = (lotteryFile, lotteryJObject);

            IValidateLottoLists validateLists = Factory.CreateValidateLottoLists();
            await validateLists.ValidateLotteryLists(lotteryInfo);



            // If true: Uses Quartz.net to schedule tasks.
            // TODO: Check against settings file to see which website scraping tasks need to be scheduled.
            if (scrapeWebsites)
            {
                Console.WriteLine("ScrapeWebsites = True");

                var props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                var quartzFactory = new StdSchedulerFactory(props);

                IScheduler scheduler = await quartzFactory.GetScheduler();
                await scheduler.Start();

                await Lotto649Schedule.Lotto649Scheduler(scheduler);
                await LottoMaxSchedule.LottoMaxScheduler(scheduler);
                await USPowerballSchedule.USPowerballScheduler(scheduler);
            }

            //Console.ReadKey();

            while (true)
            {
            }
        }
    }
}

// The below are aimed for the addition of the web app.
// TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
// TODO: Clean up logfile at various points.

// TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.

