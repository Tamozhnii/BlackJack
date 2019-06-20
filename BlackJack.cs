using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJack
    {
        static CardDeck deck;
        Gamer gamer;
        Dealer dealer;
        BJDB bd;
        
        public BlackJack()
        {
            bd = new BJDB();
        }

        public void Answer(string question, out bool flag)
        {
            string y = null;
            Console.WriteLine(question);
            y = Console.ReadLine();
            if (y != "")
            {
                switch (y[0])
                {
                    case 'y':
                    case 'Y':
                        flag = true;
                        break;
                    case 'n':
                    case 'N':
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Deafalt answer, try again");
                        Answer(question, out flag);
                        break;
                }
            }
            else Answer(question, out flag);
        }
        void ShowHands(Gamer who)
        {
            string str = who.GetType() == typeof(Gamer) ? "Your" : "Dealers";
            Console.WriteLine($"{str} hand: {who.Hand}, sum: {who.Sum}");
        }
        public static string TakeCardFromDeck()
        {
            return deck.GetCard();
        } 

        public void Play()
        {
            deck = new CardDeck();
            gamer = new Gamer();
            gamer.TakeCard();
            ShowHands(gamer);
            if (gamer.Sum == 21)
            {
                Console.WriteLine("Black Jack, You WIN!");
                Console.ReadKey();
            }
            else
            {
                bool flag = false;
                do
                {
                    if(flag)
                    {
                        gamer.TakeCard();
                        ShowHands(gamer);
                    }
                    if (gamer.Sum > 21)
                    {
                        Console.WriteLine("Bust! You lose");
                        break;
                    }
                    else if (gamer.Sum == 21)
                    {
                        break;
                    }
                    Answer("More card?", out flag);
                } while (flag);
                if(gamer.Sum <= 21)
                {
                    dealer = new Dealer();
                    dealer.DealerPlay();
                    if (dealer.Sum > 21)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("You win!");
                    }
                    else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Dealer wins, you lose");
                    }
                    else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Push!");
                    }
                }
            }
        }
    }
}
