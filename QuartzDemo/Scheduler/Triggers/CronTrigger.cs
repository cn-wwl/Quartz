using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Scheduler.Triggers
{
    /// <summary>
    /// Corn触发器
    /// </summary>
    public class CronTrigger
    {
        /// <summary>
        /// 创建 Corn触发器
        /// </summary>
        /// <param name="triggerName">触发器名称</param>
        /// <param name="group">分组名称</param>
        /// <param name="cron">触发条件</param>
        /// <returns></returns>
        public ICronTrigger CreateCronTrigger(string triggerName, string group, string cron)
        {
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                   .WithIdentity(triggerName, group)
                   .WithCronSchedule(cron)
                   .Build();
            return trigger;
        }

    }
}
