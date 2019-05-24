﻿using System;
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
                        return true;
                    case 'n':
                    case 'N':
                        return false;
                    default:
                        Console.WriteLine("Deafalt answer, try again");
                        Console.ReadKey();
                        break;
                }
            }
            else Answer();
            return false;
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
            if (gamer.Sum == 21)
            {
                Console.WriteLine("Black Jack, You WIN!");
                Console.ReadKey();
            }
            else
            {
                bool flag = true;
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
                        Console.WriteLine("You win!");
                        break;
                    }
                    flag = Answer();
                } while (flag);
                if(gamer.Sum < 21)
                {
                    dealer = new Dealer();
                    dealer.DealerPlay();
                    if (dealer.Sum > 21)
                    {
                        ShowHands(gamer);
                        ShowHands(dealer);
                        Console.WriteLine("You win!");
                    }
                    else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                    {
                        ShowHands(gamer);
                        ShowHands(dealer);
                        Console.WriteLine("Dealer wins, you lose");
                    }
                    else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                    {
                        ShowHands(gamer);
                        ShowHands(dealer);
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        ShowHands(gamer);
                        ShowHands(dealer);
                        Console.WriteLine("Push!");
                    }
                }
            }
        }
    }
}
