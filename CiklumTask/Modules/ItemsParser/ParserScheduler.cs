using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiklumTask.Modules.ItemsParser
{
    public class ParserScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ParserJob>().Build();

            ITrigger trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger1", "group1")    
                .StartNow()                            
                .WithSimpleSchedule(x => x            
                    .WithIntervalInMinutes(20)          
                    .RepeatForever())                   
                .Build();                               

            await scheduler.ScheduleJob(job, trigger);        
        }
    }
}