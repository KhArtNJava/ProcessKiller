using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessKillerService
{
    class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Greetings from HelloJob!");

            var allProcceses = Process.GetProcesses();

            foreach (Process p in allProcceses)
            {
                string n = p.ProcessName;
                if (n.Contains("CompatTelRunner"))
                {
                 //   Console.WriteLine(n);
                    p.Kill();
                }
                //if (n.Contains("notepad++"))
                //{
                //    p.Kill();
                //}

            }

            Service1.writer.Flush();
            Service1.ostrm.Flush();
        }
    }
}
