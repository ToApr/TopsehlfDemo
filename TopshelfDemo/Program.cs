using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger("main");
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.OnException(e => {
                   


                });
                x.Service<DogService>(s =>                                   //2
                {
                    s.ConstructUsing(name => new DogService());                //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("TopShelfDemo 消费者任务");                   //7
                x.SetDisplayName("TopshelfDemo");                                  //8
                x.SetServiceName("TopshelfDemo");
                x.StartAutomatically();//9
                log.InfoFormat("程序启动！开始监听!");
            });                                                             //10
           
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }
    }
}
