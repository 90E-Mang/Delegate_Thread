using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex09_Thread_ThreadPriority
{
    class Test
    {
        private int limit = 0;

        public void Print1()
        {
            int count = 0;
            int hash = Thread.CurrentThread.GetHashCode();
            //메서드의 구분을 위해서
            while (count < 50)
            {
                Console.WriteLine("Print1:{0} - {1}", hash, limit++);
                count++;
                //Thread.Sleep(100);
            }
        }
        public void Print2()
        {
            int count = 0;
            int hash = Thread.CurrentThread.GetHashCode();
            //메서드의 구분을 위해서
            while (count < 50)
            {
                Console.WriteLine("Print2:{0} - {1}", hash, limit++);
                count++;
                //Thread.Sleep(100);
            }
        }
        public void Print3()
        {
            int count = 0;
            int hash = Thread.CurrentThread.GetHashCode();
            //메서드의 구분을 위해서
            while (count < 50)
            {
                Console.WriteLine("Print3:{0} - {1}", hash, limit++);
                count++;
                //Thread.Sleep(100);
            }
        }
        public void Print4()
        {
            int count = 0;
            int hash = Thread.CurrentThread.GetHashCode();
            //메서드의 구분을 위해서
            while (count < 50)
            {
                Console.WriteLine("Print4:{0} - {1}", hash, limit++);
                count++;
                // Thread.Sleep(100);
            }
        }
        public void Print5()
        {
            int count = 0;
            int hash = Thread.CurrentThread.GetHashCode();
            //메서드의 구분을 위해서
            while (count < 50)
            {
                Console.WriteLine("Print5:{0} - {1}", hash, limit++);
                count++;
                //  Thread.Sleep(100);
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {

            Test t = new Test();
            Thread t1 = new Thread(new ThreadStart(t.Print1));
            Thread t2 = new Thread(new ThreadStart(t.Print2));
            Thread t3 = new Thread(new ThreadStart(t.Print3));
            Thread t4 = new Thread(new ThreadStart(t.Print4));
            Thread t5 = new Thread(new ThreadStart(t.Print5));

            t3.Priority = ThreadPriority.Highest;
            t1.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();
            t4.Start();
            t5.Start();
            t3.Start();
        }
    }
}