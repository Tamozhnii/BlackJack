using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class CardDeck
    {
        List<string> deck;
        Random random = new Random();
        
        public CardDeck()
        {
            deck = new List<string>();
            string[] cardSuit = new string[4] { "Hearts", "Diamonds", "Spades", "Clubs" };
            string[] cardValue = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K" };
            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardValue.Length; j++)
                {
                    deck.Add(cardValue[j] + " " + cardSuit[i] + " ");
                }
            }
        }
        public string GetCard()
        {
            if(deck == null) deck = new List<string>();
            int i = random.Next(deck.Count - 1);
            string card = deck[i];
            deck.RemoveAt(i);
            return card;
        }

    }
}
