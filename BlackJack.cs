using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BlackJack
{
    public class BlackJack
    {
        static CardDeck deck;
        Gamer gamer;
        Dealer dealer;
        BJDB db;
        
        public BlackJack()
        {
            db = new BJDB();
        }

        public void StatInsert(string result)
        {
            string gamerHand = gamer.Hand;
            string dealerHand = null;
            if (dealer.Hand != null)
            {
                dealerHand = dealer.Hand;
            }
            if (result == "Black Jack")
            {
                db.DbInsert("Win", gamerHand, dealerHand);
                db.DbInsert("StatResult", "Black Jack");
                db.DbInsert("StatResult", "Win");
            }
            else if (result == "Win")
            {
                db.DbInsert("Win", gamerHand, dealerHand);
                db.DbInsert("StatResult", "Win");
            }
            else if (result == "Bust")
            {
                db.DbInsert("Lose", gamerHand, dealerHand);
                db.DbInsert("StatResult", "Bust");
                db.DbInsert("StatResult", "Lose");
            }
            else if (result == "Lose")
            {
                db.DbInsert("Lose", gamerHand, dealerHand);
                db.DbInsert("StatResult", "Lose");
            }
            else
            {
                db.DbInsert("Push", gamerHand, dealerHand);
                db.DbInsert("StatResult", "Push");
            }
            string g = null;
            foreach (char i in gamerHand)
            {
                while(i != ' ')
                {
                    g += i;
                }
                if(g != null && (i == ' ' || i.ToString() == null))
                {
                    if(g.Length > 0 && g.Length <= 2)
                    {
                        db.DbInsert("CardsValue", g);
                    }
                    else
                    {
                        db.DbInsert("CardsLear", g);
                    }
                    g = null;
                }
            }
            foreach (char i in dealerHand)
            {
                while (i != ' ')
                {
                    g += i;
                }
                if (g != null && (i == ' ' || i.ToString() == null))
                {
                    if (g.Length > 0 && g.Length <= 2)
                    {
                        db.DbInsert("CardsValue", g);
                    }
                    else
                    {
                        db.DbInsert("CardsLear", g);
                    }
                    g = null;
                }
            }
        }
        public void StatDB()
        {
            db.DbStat("CardsLear");
            db.DbStat("CardsValue");
            db.DbStat("StatResult");
            Console.WriteLine("What game number are you want to see?");
            int a = int.Parse(Console.ReadLine());
            db.DbStat(a);
        }
        public void CloseDB()
        {
            db.DbClose();
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
                StatInsert("Black Jack");
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
                        StatInsert("Bust");
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
                        StatInsert("Win");
                        Console.WriteLine("You win!");
                    }
                    else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                    {
                        ShowHands(dealer);
                        StatInsert("Lose");
                        Console.WriteLine("Dealer wins, you lose");
                    }
                    else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                    {
                        ShowHands(dealer);
                        StatInsert("Win");
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        ShowHands(dealer);
                        StatInsert("Push");
                        Console.WriteLine("Push!");
                    }
                }
            }
        }
    }
}
