using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Gamer
    {
        List<string> hand = new List<string>();
        protected int sum = 0;

        public int Sum
        {
            get { return sum; }
        }
        public string Hand
        {
            get
            {
                return String.Concat(hand);
            }
        }

        public Gamer()
        {
            hand.Add(CardDeck.GetCard());
            GetCount();
        }

        public void TakeCard()
        {
            hand.Add(CardDeck.GetCard());
            GetCount();
        }

        public void GetCount()
        {
            int sum = 0;
            string card = null;
            for (int i = 0; i < hand.Count; i++)
            {
                card = hand[i];
                if (Char.IsDigit(card[0]) && card[0] != '1')
                {
                    sum += int.Parse(card[0].ToString());
                }
                else if (card[0] == 'A')
                {
                    sum += 11;
                }
                else
                {
                    sum += 10;
                }
            }
            foreach (string i in hand)
            {
                if (i[0] == 'A' && sum > 21) sum -= 10;
            }
        }
    }
}
