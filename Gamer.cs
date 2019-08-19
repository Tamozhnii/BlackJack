using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Gamer
    {
        List<string> hand;
        protected int sum;
        string myHand;
        string card;

        public int Sum
        {
            get { return sum; }
        }
        public string Hand
        {
            get
            {
                myHand = "";
                foreach (string v in hand)
                {
                    myHand += v + " ";
                }
                return myHand;
            }
        }

        public Gamer()
        {
            sum = 0;
            hand = new List<string>();
            TakeCard();
        }

        public string TakeCard()
        {
            string c = BlackJack.TakeCardFromDeck();
            hand.Add(c);
            sum = GetCount();
            return c;
        }

        public int GetCount()
        {
            int sum1 = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                card = hand[i];
                if (char.IsDigit(card[0]) is true && card[0] != '1')
                {
                    sum1 += int.Parse(card[0].ToString());
                }
                else if (card[0] == 'A')
                {
                    sum1 += 11;
                }
                else
                {
                    sum1 += 10;
                }
            }
            for (int j = 0; j < hand.Count; j++)
            {
                string item = hand[j];
                if (item[0] == 'A' && sum1 > 21) sum1 -= 10;
            }
            return sum1;
        }
    }
}
