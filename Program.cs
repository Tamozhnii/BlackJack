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
            blackJack.Answer("Play?", out question);
            if (question)
            {
                do
                {
                    blackJack.Play();
                    blackJack.Answer("Play again?", out question);
                } while (question);
            }
            bool stat;
            blackJack.Answer("Show stat?", out stat);
            if (stat)
            {
                blackJack.DbUpdate();
                blackJack.StatDB();
                //Console.ReadKey();
            }
            blackJack.CloseDB();
        }
    }
}
