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
            do
            {
                blackJack.Play();
            } while (blackJack.Answer() == true);
            Console.ReadKey();
        }
    }
}
