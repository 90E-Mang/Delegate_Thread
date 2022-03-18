using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex10_Thread_Lock_wroom
{
    class Wroom
    {
        // lock 문에 사용할 객체
        // private object lockObject = new object();
        public void openDoor(string name)
        {
            // lock(lockObject) <- this 대신에 위의 객체를 넣어도 된다. 사실은 이게 일반적임.
            lock (this) 
            {
                Console.WriteLine($"{name}님 화장실 입장");
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{name} 사용중 : {i}");
                    if (i == 10)
                    {
                        Console.WriteLine($"{name}님 끙 ~~~~ ");
                    }
                }
                Console.WriteLine("시원하시죠 ? ^^!");
            }            
        }
    }
    class User
    {
        Wroom wroom;
        string who;
        public User(Wroom wroom, string who)
        {
            this.who = who;
            this.wroom = wroom;
        }
        public void run()
        {
            wroom.openDoor(this.who);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 한강 둔치
            Wroom wroom = new Wroom();  // 화장실

            // 사람들
            User kim = new User(wroom, "김씨");
            User park = new User(wroom, "박씨");
            User lee = new User(wroom, "이씨");

            // 똥마려움
            // 각각의 사람들이 가지고 있는 함수를 Thread로 만들어야 됨.
            Thread kimT = new Thread(new ThreadStart(kim.run));
            Thread parkT = new Thread(new ThreadStart(park.run));
            Thread leeT = new Thread(new ThreadStart(lee.run));

            // 함수에 lock을 걸지 않고 아래처럼 start 다 해버리면 한 화장실에 3명이 들어가서 .... --> 꼬임.
            kimT.Start();
            parkT.Start();
            leeT.Start();

            
        }
    }
}
