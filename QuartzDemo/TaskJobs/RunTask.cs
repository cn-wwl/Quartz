using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace QuartzDemo.TaskJobs
{
    public class RunTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now} 跑步");
        }
    }
}

