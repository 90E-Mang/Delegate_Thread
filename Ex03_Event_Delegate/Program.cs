using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Event_Delegate
{
    delegate void onClick(string what);     // 델리게이트 타입(void, parameter(string)) 대리

    class TestDel
    {
        public void MouseClick(string what)
        {
            Console.WriteLine($"마우스 {what} 버튼이 클릭");
        }
        public void keyboardClick(string what)
        {
            Console.WriteLine($"키보드 {what} 좌판이 클릭");
        }
    }
    class Program
    {
        public event onClick myClick;   // 이벤트 onClick 델리게이트 형식을 이벤트 핸들러로 가진다
        static void Main(string[] args)
        {
            TestDel testDel = new TestDel();
            Program m = new Program();

            m.myClick += new onClick(testDel.MouseClick);
            // myClick 이라는 사건(이벤트)가 발생하면... onClick 델리게이트를 통해서 등록된 핸들러 함수를 호출한다.
            // 이벤트에 등록할 때는 이름을 생략하고 하면 된다.
            // 단, testDel.MouseClick 에 등록되는 함수는 형식이 onClick 이라는 delegate 형식과 동일해야됨.
            m.myClick += new onClick(testDel.keyboardClick);
            m.myClick("왼쪽");
        }
    }
}
