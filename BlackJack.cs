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
        bool flag = true;

        public BlackJack() { }

        public bool Answer()
        {
            string y = null;
            Console.WriteLine("More?");
            y = Console.ReadLine();
            if (y != "")
            {
                switch (y[0])
                {
                    case 'y':
                    case 'Y':
                        break;
                    case 'n':
                    case 'N':
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Deafalt answer, try again");
                        Console.ReadKey();
                        break;
                }
            }
            else Answer();
            return flag;
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
            dealer = new Dealer();
            ShowHands(dealer);
            ShowHands(gamer);

            if (gamer.Sum == 21)
            {
                Console.WriteLine("Black Jack, You WIN!");
                Console.ReadKey();
            }
            else
            {
                do
                {
                    Answer();
                    if(flag == true)
                    {
                        gamer.TakeCard();
                    }
                    if (gamer.Sum > 21)
                    {
                        ShowHands(gamer);
                        Console.WriteLine("Bust! You lose");
                        Console.ReadKey();
                        break;
                    }
                    else if (gamer.Sum == 21)
                    {
                        ShowHands(gamer);
                        break;
                    }
                } while (flag == true);
                dealer.DealerPlay();
                if (dealer.Sum > 21)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("You win!");
                    Console.ReadKey();
                }
                else if (dealer.Sum < 21 && dealer.Sum > gamer.Sum)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("Dealer wins, you lose");
                    Console.ReadKey();
                }
                else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("You Win!");
                    Console.ReadKey();
                }
                else
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("Push!");
                    Console.ReadKey();
                }
            }
        }
    }
}
