using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Ex06_Process_Thread_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();
            string Processname = proc.ProcessName;
            DateTime startTime = proc.StartTime;
            int proid = proc.Id;
            Console.WriteLine("[현재 프로세스 정보 출력]");
            Console.WriteLine("{0} - {1} - {2}", Processname, startTime, proid);
            Console.WriteLine(proc.HasExited);

            //문제 : Process.GetProcesses();
            Process[] pros = Process.GetProcesses();

            Console.WriteLine("[전체 프로세스 정보]");
            foreach (Process p in pros)
            {
                Console.WriteLine("{0}", p.ProcessName);
            }

        }
    }
}