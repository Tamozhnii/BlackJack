using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJack blackJack = new BlackJack();
            bool flag = false;
            do
            {
                blackJack.Play();
                flag = blackJack.Answer();
            } while (flag == true);
            Console.ReadKey();
        }
    }
}
