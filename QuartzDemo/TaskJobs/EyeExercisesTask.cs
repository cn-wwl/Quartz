using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.TaskJobs
{
    class EyeExercisesTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now} 做眼保健操！");
        }
    }
}
