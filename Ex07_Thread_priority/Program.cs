using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Diagnostics;
namespace Ex07_Thread_priority
{
    class Program
    {
        static void method()
        {
            Console.WriteLine("A");
        }

        static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();
            ThreadStart ts = new ThreadStart(method);
            Thread th = new Thread(ts);
            th.Start();
            ProcessThreadCollection ths = proc.Threads;

            int ThreadID;
            DateTime StartTime;
            int Priority;
            System.Diagnostics.ThreadState thstate;



            Console.WriteLine("현재 프로세스에 실행중인 스레드수:{0}", ths.Count);

            foreach (ProcessThread pth in ths)
            {
                ThreadID = pth.Id;
                StartTime = pth.StartTime;
                Priority = pth.BasePriority;
                thstate = pth.ThreadState;

                Console.WriteLine("{0} - {1}  - {2} - {3}", ThreadID, StartTime, Priority, thstate);
            }
        }
    }
}