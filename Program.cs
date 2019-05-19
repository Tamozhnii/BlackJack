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
        string[] mast = new string[4] { " Hearts, ", " Diamonds, ", " Spades, ", " Clubs, " };
        string[] character = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K" };
        List<string> hand = new List<string>();

        public string Hand
        {
            get
            {
                string myHand = null;
                for (int i = 0; i < hand.Count; i++)
                {
                    myHand += hand[i];
                }
                return myHand;
            }
        }
        public BlackJack()
        {
            for (int i = 0; i < mast.Length; i++)
            {
                for (int j = 0; j < character.Length; j++)
                {
                    cards.Add(character[j] + mast[i]);
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
            int sum = 0;
            int cardCost = 0;
            string card = null;
            string cost;
            for (int i = 0; i < hand.Count; i++)
            {
                card = hand[i];
                cost = card[0].ToString() + card[1];
                int.TryParse(cost, out cardCost);
                if (cardCost >= 2 || cardCost <= 10)
                {
                    sum += cardCost;
                }
                if (card[0] == 'J' || card[0] == 'D' || card[0] == 'K')
                {
                    sum += 10;
                } else if (card[0] == 'A')
                {
                    sum += 11;
                }
            }
            if(sum > 21)
            {
                foreach (string i in hand)
                {
                    if (i[0] == 'A') sum -= 10;
                }
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BlackJack myHand = new BlackJack();
            for (int i = 0; i < 5; i++)
            {
                myHand.GetCard();
            }
            Console.WriteLine($"Hand {myHand.Hand}it's {myHand.Sum()} point");

            Console.ReadKey();
        }
    }
}
