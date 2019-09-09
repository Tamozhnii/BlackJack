using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    class Program
    {
        string Stat(BlackJack b)
        {
            b.DbUpdate();
            return b.StatDB();
        }

        bool Exit(out bool b)
        {
            return b = true;
        }

        void Play(BlackJack b)
        {
            b.Play();
        }

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
            if (stat)
            {
                blackJack.DbUpdate();
                blackJack.StatDB();
                Console.ReadKey();
            }
            blackJack.CloseDB();
        }
    }
}
