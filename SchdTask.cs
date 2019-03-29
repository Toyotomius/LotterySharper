using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;


namespace LotteryCore
{
    public class SchdTask
    {
        public async void Schedule()
        {
            IJobDetail job = JobBuilder.Create<HelloJob>().WithIdentity("myJob", "group1").Build();
            var trigger = TriggerBuilder.Create().WithIdentity("test", "group1")
                .WithCronSchedule("0/30 * * * * ?").ForJob("myJob", "group1").Build();

            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            SchdTask schdtask = new SchdTask();
            await sched.ScheduleJob(job, trigger);
        }
    }

    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            WebsiteScraping ws = new WebsiteScraping();
            Console.WriteLine($"{DateTime.Now}  : Starting Scrape");
            ws.Scrape();
        }
    }
}
