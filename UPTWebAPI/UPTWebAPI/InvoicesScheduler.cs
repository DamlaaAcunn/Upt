
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPTWebAPI
{
    public class InvoicesScheduler
    {
        public static IScheduler Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler().Result;
            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }

        public static async void InvoicesJobScheduler()
        {
            try
            {
                var iys = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IysSchdule"]);
                if (iys == true)
                {
                    IScheduler sched = Start();
                    //Eğer ay sonundan 2 gün önce ise bu kod çalışsın.
                    DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-2);
                    if (DateTime.Now >= date)
                    {
                        IJobDetail IysSendCdbAppJob = JobBuilder.Create<InvoicesJob>().WithIdentity("InvoicesJob", null).Build();
                        ITrigger trigger = TriggerBuilder.Create()
                       .WithDailyTimeIntervalSchedule
                         (s =>
                            s.WithIntervalInHours(24)
                           .OnEveryDay() //hergün çalışacağı bilgisi
                           .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(09, 00)) //hergün hangi saatte çalışacağı bilgisi
                                                                                  //s.WithIntervalInMinutes(55)
                           )
                       .Build();
                        var result = await sched.ScheduleJob(IysSendCdbAppJob, trigger);
                    }

                }
            }
            catch (Exception exp)
            {

            }


        }
    }
}