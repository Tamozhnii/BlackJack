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
        static void Main(string[] args)
        {
            // Временно
            bool b = true;
            Service service = new Service();

            // Подключение

            Uri address = new Uri("ftp://localhost:333/IContract"); //??
            NetMsmqBinding binding = new NetMsmqBinding();
            Type contract = typeof(IContract); //??
            ServiceHost host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, binding, address.ToString());
            host.Open();

            // Логика

            service.IPlay();
            service.IMoreCard(b);
            service.IReplay(b);
            service.IStat();
            service.IExit();

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


            host.Close();
        }
    }
}
