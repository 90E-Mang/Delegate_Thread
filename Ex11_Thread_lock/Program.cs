using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Ex11_Thread_lock
{
    class Account
    {
        int money;
        Random rnd = new Random();
        public Account(int money)
        {
            this.money = money;
        }
        private int Deposit(int amount) //입금
        {
            lock (this)
            {
                Console.WriteLine("{0}님이 {1}을 입금하려 합니다", Thread.CurrentThread.Name, amount);
                Console.WriteLine("입금전 잔액:{0}", this.money);
                Console.WriteLine("입금 금액:{0}", amount);
                this.money += amount;
                Console.WriteLine("입금후 예금 잔액:{0}", this.money);
            }
            return amount;
        }
        private int WithDraw(int amount) //출금
        {
            if (this.money < 0)
            {
                throw new Exception("인출 가능 금액이 없습니다");
            }
            // lock (this)
            // {
            if (this.money >= amount)
            {
                Console.WriteLine("{0}님이 {1}를 인출하려고 합니다", Thread.CurrentThread.Name, amount);
                Console.WriteLine("인출전 예금 금액:{0}", this.money);
                Console.WriteLine("인출 금액:{0}", amount);
                this.money -= amount;
                Console.WriteLine("인출 후 예금 잔액:{0}", this.money);
                return amount;
            }
            else
            {
                return 0; //인출금액 현재 보다 많은 경우
            }
            // }
        }

        public void Trans()
        {
            for (int i = 0; i < 10; i++)
            {
                int money = rnd.Next(-500, 501);
                if (money > 0)
                {
                    if (this.WithDraw(money) == 0)
                    {
                        Console.WriteLine("##ERROR:잔액이 부족합니다");
                    }
                }
                else
                {
                    this.Deposit(money * -1);
                }
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread[] th = new Thread[5];
            Account objcount = new Account(1000);
            for (int i = 0; i < th.Length; i++)
            {
                th[i] = new Thread(new ThreadStart(objcount.Trans));
                th[i].Name = "고객[ " + i + " ]";
            }
            for (int i = 0; i < th.Length; i++)
            {
                th[i].Start();
            }
        }
    }
}