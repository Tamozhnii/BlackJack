using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJack
    {
        public static bool Answer()
        {
            bool flag = false;
            Console.WriteLine("More card?");
            string y = Console.ReadLine();
            do
            {
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
                            break;
                        default:
                            Console.WriteLine("Deafalt answer, try again");
                            Answer();
                            break;
                    }
                } else Answer();
            } while (flag == true);
            return flag;
        }
        public static void ShowHands(Gamer who)
        {
            string str = who.GetType() == typeof(Gamer) ? "Your" : "Dealers";
            Console.WriteLine($"{str} hand: {who.Hand.ToString()}, sum: {who.Sum.ToString()}");
        }
        public BlackJack()
        {
            Gamer gamer = new Gamer();
            ShowHands(gamer);
            if (gamer.Sum == 21)
            {
                ShowHands(gamer);
                Console.WriteLine("Black Jack, You WIN!");
            }
            else
            {
                while (Answer() == true)
                {
                    gamer.TakeCard();
                    if (gamer.Sum > 21)
                    {
                        ShowHands(gamer);
                        Console.WriteLine("Bust! You lose");
                    }
                    else if (gamer.Sum == 21)
                    {
                        ShowHands(gamer);
                        break;
                    }
                }
                Dealer dealer = new Dealer();
                ShowHands(dealer);
                if (dealer.Sum > 21)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("You win!");
                }
                else if (dealer.Sum < 21 && dealer.Sum > gamer.Sum)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("Dealer wins, you lose");
                } else if(dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("You Win!");
                } else
                {
                    ShowHands(gamer);
                    ShowHands(dealer);
                    Console.WriteLine("Push!");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //BlackJack blackJack = new BlackJack();
            Dealer dealer = new Dealer();
            Gamer gamer = new Gamer();
            Console.WriteLine($"Dealer {dealer.Hand} sum = {dealer.Sum}");
            Console.WriteLine($"Hand {gamer.Hand} sum = {gamer.Sum}");
            Console.ReadKey();
        }
    }
}
