using IBlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    class Program
    {
        static string Play(ref bool b, BlackJack bj)
        {
            if (b)
            {
                return bj.Answer(out b);
            }
            else
            {
                b = false;
                return bj.Answer();
            }
        }

        static bool Play(bool a, int b, BlackJack bj)
        {
            if (b != 1)
            {
                bj.Exit();
                bj = null;
                return a = false;
            }
            else
            {
                bj.Start();
                return a = true;
            }
        }

        static void Again(bool a, BlackJack bj)
        {

            if(a) bj.Start();
            bj.Exit();
        }

        static void Main(string[] args)
        {
            BlackJack blackJack = new BlackJack();
            int a = 0;
            bool ans = true;
            Console.WriteLine("1. Играть\n2. Статистика\n3. Закрыть");
            int.TryParse(Console.ReadLine(), out a);
            switch (a)
            {
                case 1:
                    blackJack.Start();
                    break;
                case 2:
                    blackJack.Stat();
                    break;
                default:
                    blackJack.Exit();
                    blackJack = null;
                    ans = false;
                    break;
            }
            if(a == 2)
            {
                Console.WriteLine("Играть?");
                int.TryParse(Console.ReadLine(), out a);
                ans = Play(ans, a, blackJack);
            }
            while (ans)
            {
                while (ans)
                {
                    Console.WriteLine(blackJack.ShowHands());
                    Console.WriteLine("Еще?");
                    bool.TryParse(Console.ReadLine(), out ans);
                    Play(ref ans, blackJack);
                }
                Console.WriteLine("Играть снова?");
                bool.TryParse(Console.ReadLine(), out ans);
                Again(ans, blackJack);
            }

            // Временно
            // bool b = true;
            // Service service = new Service();

            // Подключение

            //Uri address = new Uri("ftp://localhost:333/IContract"); //??
            // NetMsmqBinding binding = new NetMsmqBinding();
            // Type contract = typeof(IContract); //??
            // ServiceHost host = new ServiceHost(typeof(Service));
            // host.AddServiceEndpoint(contract, binding, address.ToString());
            // host.Open();

            // Логика

            // service.IPlay();
            // service.IMoreCard(b);
            // service.IReplay(b);
            // service.IStat();
            // service.IExit();

            //BlackJack blackJack = new BlackJack();
            //bool question;
            //blackJack.Answer(question);
            //if (question)
            //{
            //    do
            //    {
            //        blackJack.Play();
            //        blackJack.Answer(question);
            //    } while (question);
            //}
            //bool stat;
            //blackJack.Answer(stat);
            //if (stat)
            //{
            //    blackJack.DbUpdate();
            //    blackJack.StatDB();
            //    //Console.ReadKey();
            //}
            //blackJack.CloseDB();


            //host.Close();
        }
    }
}
