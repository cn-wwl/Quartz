using Quartz;
using Quartz.Impl;
using QuartzDemo.Scheduler.Jobs;
using QuartzDemo.Scheduler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Scheduler
{
    public class QuartzFactory
    {
        private StdSchedulerFactory factory = null;

        //调度器集合
        public Dictionary<string, IScheduler> schedulers = new Dictionary<string, IScheduler>();

        public QuartzFactory()
        {
            BuildSchedulerFactory();
        }
        private void BuildSchedulerFactory()
        {
            // 实例化调度器工厂
            factory = new StdSchedulerFactory();
        }

        /// <summary>
        /// 新增调度器
        /// </summary>
        /// <param name="name">调度器名称</param>
        public void AddScheduler(string name)
        {
            if (!schedulers.Any(a => a.Key.Equals(name)))
            {
                schedulers.Add(name, factory.GetScheduler());
            }
        }

        /// <summary>
        /// 移除调度器
        /// </summary>
        /// <param name="name">调度器名称</param>
        public void RemoveScheduler(string name)
        {
            if (schedulers.Any(a => a.Key.Equals(name)))
            {
                schedulers.Remove(name);
            }
        }



        /// <summary>
        /// 创建任务
        /// </summary>
        /// <typeparam name="T">Job包</typeparam>
        /// <param name="scheduler">调度器名称</param>
        /// <param name="name">任务名称</param>
        /// <param name="group">分组名称</param>
        /// <param name="cron">触发条件</param>
        public void AddTask<T>(string scheduler, string name, string group, string cron) where T : IJob
        {
            CronTrigger cronTrigger = new CronTrigger();
            var trigger = cronTrigger.CreateCronTrigger(name, group, cron);

            TaskJob mtrJob = new TaskJob();
            var job = mtrJob.CreateReadingMtrJob<T>(name, group);

            schedulers[scheduler].ScheduleJob(job, trigger);
        }

    }
}
