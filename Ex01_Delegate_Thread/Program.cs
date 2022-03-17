using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_Delegate_Thread
{
    // 델리게이트는 하나의 type 이다
    // 함수를 대리해서 실행함.(함수를 감추어서 캡슐화)
    // 조건 : 대리하고자 하는 함수의 형식과 동일해야 된다(단, static이건 아니건은 상관없다)
    //       여러개의 동일한 형식의 함수를 대리할 수 있다.

    delegate void simple();
    delegate void simple2(int x);
    delegate void staticDel();
    delegate string simple3(string x);

    // 함수를 대리해서 호출하는 형식(Type)을 생성

    class Test
    {
        public void fMethod()
        {
            Console.WriteLine("일반메서드");
        }
        public void fMethod2(int i)
        {
            Console.WriteLine($"값 : {i}");
        }
        public static void sMethod()
        {
            Console.WriteLine("정적 메서드");
        }
        public string fMethod3(string s)
        {
            return s + "입니다";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            // t.fMethod();  <- 원래 이렇게 했었음.
            simple s = new simple(t.fMethod); //delegate도 type라서 이렇게 선언 해야함.
            s(); // s가 대리해서 호출

            simple2 s2 = new simple2(t.fMethod2);
            s2(10);

            simple3 s3 = new simple3(t.fMethod3);
            string str = s3("이맹기");
            Console.WriteLine(str);

            //Test.sMethod
        }
    }
}
