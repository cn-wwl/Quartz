using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Scheduler.Jobs
{
    public class TaskJob
    {
        /// <summary>
        /// 创建任务作业
        /// </summary>
        /// <typeparam name="T">Job</typeparam>
        /// <param name="jobName">任务名称</param>
        /// <param name="group">分组名称</param>
        /// <returns></returns>
        public IJobDetail CreateReadingMtrJob<T>(string jobName, string group) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>().WithIdentity(jobName, group).Build();
            return job;
        }
    }
}
