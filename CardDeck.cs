using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class CardDeck
    {
        List<int> deck = new List<int>();
        Random random = new Random();
        
        public CardDeck()
        {
            for(int i = 1; i <= 52; i++)
            {
                deck.Add(i);
            }
        }
        public int GetCard()
        {
            int i = random.Next(1, deck.Count() - 1);
            int card = deck[i];
            deck.RemoveAt(i);
            return card;
        }

    }
}
