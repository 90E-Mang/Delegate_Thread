using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex08_Thread_Run
{
    class Program
    {

        static void SPrint()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("첫번째 스레드:{0}", i);
                //Thread.Sleep(100);
            }

        }
        public void Print()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("두번째 스레드:{0}", i);
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {

            Program m = new Program();

            ThreadStart ts = new ThreadStart(Program.SPrint);
            Thread th = new Thread(ts);

            ThreadStart ts2 = new ThreadStart(m.Print);
            Thread th2 = new Thread(ts2);

            th.Start();
            th2.Start();

        }
    }
}