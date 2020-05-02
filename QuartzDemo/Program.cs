using QuartzDemo.Scheduler;
using QuartzDemo.TaskJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建调度工厂
            QuartzFactory quartzFactory = new QuartzFactory();

            //添加调度器
            quartzFactory.AddScheduler("Life");

            //为指定调度器添加任务
            quartzFactory.AddTask<RunTask>("Life", "RunTask", "Bodybuilding", "0 0 06 1/1 * ? *");
            quartzFactory.AddTask<EyeExercisesTask>("Life", "EyeExercisesTask", "Bodybuilding", "0 0 19 1/1 * ? *");

            //启动调度器
            quartzFactory.schedulers["Life"].Start();
        }
    }
}
