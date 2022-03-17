using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex04_Thread
{
    // 하나의 프로세스에 한개의 Thread를 동작(지금까지 한 방식)
    // 한개의 Thread (Main() 함수 >> stack 메모리 사용)

    // 하나의 프로세스에서 여러개의 일꾼(Thread)를 만들어서 사용하겠다.
    // 일꾼(stack, Thread)를 만들어서 사용 !

    // 멀티 Thread의 문제점 ? -> 공유자원....

    // 1. System.Threading.ThreadStar 델리게이트 (동작할 함수)
    // 2. Thread 객체를 생성하고 델리게이트를 통해서 함수 등록
    class Program
    {
        public static void sPrint()
        {
            Console.WriteLine("static 함수 ");
        }
        public void Print()
        {
            Console.WriteLine("일반 함수 ");
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            ThreadStart t = new ThreadStart(program.Print);
            ThreadStart t2 = new ThreadStart(Program.sPrint);

            //Thread th = new Thread(new ThreadStart(program.Print)); // 이거도 가능

            Thread th = new Thread(t);
            Thread th2 = new Thread(t2);

            th.Start(); // start를 걸면 stack이 하나 생성되고 그 stack >> program.Print 올려 놓고 start 함수 자체는 종료
            th2.Start(); // start를 걸면 stack이 하나 생성되고 그 stack >> Program.sPrint 올려 놓고 start 함수 자체는 종료
            Console.WriteLine("나는 메인(나도 쓰레드)");
        }
    }
}
