using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJack
    {
        Random random = new Random();
        List<string> cards = new List<string>();
        string[] mast = new string[4] { " Hearts", " Diamonds", " Spades", " Clubs" };
        string[] character = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K"};
        List<string> hand = new List<string>();

        public string[] Cards
        {
            set
            {
                for (int i = 0; i < mast.Length; i++)
                {
                    for (int j = 0; j < character.Length; j++)
                    {
                        cards.Add(character[j] + mast[i]);
                    }
                }
            }
        }

        public List<string> GetCard()
        {
            int i = random.Next(0, cards.Count - 1);
            hand.Add(cards[i]);
            cards.RemoveAt(i);
            return hand;
        }
        
        public int Sum()
        {
            List<char> list;
            int sum = 0;
            for (int i = 0; i < hand.Count - 1; i++)
            {
                list = new List<char>();
                list.AddRange(hand[i]);
                int a = 0;
                int.TryParse(list[0].ToString(), out a);
                if(a >= 2 || a <= 10)
                {
                    sum += a;
                } else if(list[0] == 'J' || list[0] == 'D' || list[0] == 'k')
                {
                    sum += 10;
                } else if(list[0] == 'A')
                {
                    if (sum < 11) sum += 11;
                    else if (sum > 21) sum -= 10;
                    else sum += 1;
                }
            }
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
