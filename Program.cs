using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJack
    {
        string[] cards = new string[62];
        string[] mast = new string[4] { " Hearts", " Diamonds", " Spades", " Clubs" };
        string[] character = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K"};
        public string[] Cards
        {
            set
            {
                for (int i = 0; i < character.Length; i++)
                {
                    for (int j = 0; j < mast.Length; j++)
                    {
                        cards[i * 4 + j] = character[i] + mast[j];
                    }
                }
            }
        }

        public string GetCard()
        {
            Random random = new Random();
            string card = cards[random.Next(0, cards.Length - 1)];
            return card;
        }
        public int Sum()
        {
            int sum = 0;

            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
