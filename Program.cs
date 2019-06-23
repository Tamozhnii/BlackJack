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
            bool stat = false;
            blackJack.Answer("Show stat?", out stat);
            if (stat == true)
            {
                blackJack.StatDB();
            }
            blackJack.CloseDB();
        }
    }
}
