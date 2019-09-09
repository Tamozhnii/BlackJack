using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Gamer
    {
        List<int> hand;
        protected int sum;
        string myHand;

        public int Sum
        {
            get { return sum; }
        }
        public string Hand
        {
            get
            {
                myHand = "";
                foreach (int v in hand)
                {
                    myHand += v + " ";
                }
                return myHand;
            }
        }

        public Gamer()
        {
            sum = 0;
            hand = new List<int>();
        }

        public int TakeCard()
        {
            int c = BlackJack.TakeCardFromDeck();
            hand.Add(c);
            sum = GetCount();
            return c;
        }

        public int GetCount()
        {
            int sum1 = 0;

            for (int i = 0; i < hand.Count; i++)
            {
                for (int j = 0; j < 4; j += 13)
                {
                    if (hand[i] - j == 1)
                    {
                        sum1 += 11;
                    }
                    else if (hand[i] - j > 10 && hand[i] - j < 14)
                    {
                        sum1 += 10;
                    }
                    else if (hand[i] - j <= 10)
                    {
                        sum1 += hand[i];
                    }
                }
            }
            for (int j = 0; j < hand.Count; j++)
            {
                for (int i = 0; i < 4; i += 13)
                {
                    if (sum1 > 21 && hand[j] - i == 1) sum1 -= 10;
                }
            }
            return sum1;
        }
    }
}
