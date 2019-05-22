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
                foreach (string i in hand)
                {
                    myHand += i + " ";
                }
                return myHand;
            }
        }

        public Gamer()
        {
            TakeCard();
        }

        public void TakeCard()
        {
            hand.Add(BlackJack.TakeCardFromDeck());
            GetCount();
        }

        public void GetCount()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                card = hand[i];
                if (Char.IsDigit(card[0]) == true && card[0] != '1')
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
