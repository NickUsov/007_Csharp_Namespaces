using System;
using static System.Console;
using Bankomat;

namespace _007_Csharp_Namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. 	Разработать приложение, в котором бы сравнивалось население трёх столиц из разных стран. Причём страна бы
            //обозначалась пространством имён, а город – классом в данном пространстве.
            WriteLine("1. exercise");
            USA.Denver denver = new USA.Denver();
            denver.Population = 680000;
            Spain.Barcelona barcelona = new Spain.Barcelona();
            barcelona.Population = 1615000;
            Ukraine.Dnipro dnipro = new Ukraine.Dnipro();
            dnipro.Population = 997168;
            if (barcelona.Population > dnipro.Population)
                WriteLine("Barcelona has more population then Dnipro");
            if (denver.Population < dnipro.Population)
                WriteLine("Denver has less population then Barcelona");

            //2. Написать приложение, имитирующее работу банкомата Реализовать классы Banc, Client, Account в различных
            //пространствах имен (общее пространство имен «Bankomat»). 
            WriteLine("2. exercise");
            WriteLine("Введите количество клиентов банка");
            int num = int.Parse(ReadLine());
            Bankomat.Finanse.Bank b = new Bankomat.Finanse.Bank();
            b.MakeClients();
            b.ShowClients();
        }
    }
}
namespace USA
{
    public class Denver
    {
        public int Population { get; set; }
    }
}
namespace Spain
{
    public class Barcelona
    {
        public int Population { get; set; }
    }
}
namespace Ukraine
{
    public class Dnipro
    {
        public int Population { get; set; }
    }
}

//2.
namespace Bankomat
{
    namespace User
    {
        class Client
        {

            Soft.Account acnt = new Soft.Account();
            public void UseAccount()
            {

                ConsoleKeyInfo mode;
                do
                {
                    Write("Сделайте ваш выбор:\nA - Проверить счет\nB - Положить на счет\nC - Снять со счета\n");
                    mode = Console.ReadKey();
                    WriteLine();
                    if (mode.Key == ConsoleKey.A)
                        this.acnt.CheckMoney();
                    if (mode.Key == ConsoleKey.B)
                        this.acnt.PutMoney();
                    if (mode.Key == ConsoleKey.C)
                        this.acnt.GetMoney();
                    if (mode.Key == ConsoleKey.D)
                        this.acnt.ShowAccount();
                    WriteLine("Продолжить? - Y");
                    mode = Console.ReadKey();
                    WriteLine();
                } while (mode.Key == ConsoleKey.Y);
            }
            public override string ToString()
            {
                return $"Логин {this.acnt.Login}, пароль {this.acnt.Pass}";
            }
        }
    }
    namespace Soft
    {
        class Account
        {

            double money;
            string login, pass;
            public Account()
            {
                Random rnd = new Random();
                string msg = "";
                int num = 0;
                while (msg.Length < 5)
                {
                    num = rnd.Next(47, 123);
                    if ((num > 47 && num < 59) || (num > 64 && num < 91) || (num > 96 && num < 123))
                        msg += (char)num;
                }
                this.login = msg;
                msg = "";
                while (msg.Length < 5)
                {
                    num = rnd.Next(47, 123);
                    if ((num > 47 && num < 59) || (num > 64 && num < 91) || (num > 96 && num < 123))
                        msg += (char)num;
                }
                this.pass = msg;
            }

            public string Login { get { return this.login; } set { this.login = value; } }
            public string Pass { get { return this.pass; } set { this.pass = value; } }
            public void GetMoney()
            {
                WriteLine("Введите сумму, которую хотите снять");
                double pay = double.Parse(ReadLine());
                if (pay <= this.money)
                    this.money -= pay;
                else
                    WriteLine("На счету недостаточно средств");
            }
            public void PutMoney()
            {
                WriteLine("Введите сумму, которую кладете на счет");
                double pay = double.Parse(ReadLine());
                this.money += pay;
            }
            public void CheckMoney()
            {
                WriteLine(this.money);
            }
            public void ShowAccount()
            {
                WriteLine("Логин " + this.login);
                WriteLine("Пароль " + this.pass);
            }
        }
    }
    namespace Finanse
    {
        class Bank
        {
            User.Client[] clnt = null;
            int size;
            public Bank()
            {
                this.size = 3;
                this.clnt = new User.Client[this.size];
            }
            public Bank(int size) : this()
            {
                this.size = size;
            }
            public void MakeClients()
            {
                for (int i = 0; i < this.size; i++)
                {
                    this.clnt[i] = new User.Client();
                    this.clnt[i].UseAccount();
                }
            }
            public void ShowClients()
            {
                for (int i = 0; i < this.size; i++)
                    WriteLine(this.clnt[i]);
            }
        }
    }
}
