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
            bool question;
            do
            {
                blackJack.Play();
                blackJack.Answer("Play again?", out question);
            } while (question);
        }
    }
}
