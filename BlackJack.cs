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
        static BJDB bd = new BJDB();
        static Task task;
        
        public BlackJack()
        {
            db = new BJDB();
        }

        public void StatInsert(string result)
        {
            string gamerHand = gamer.Hand;
            string dealerHand = null;
            if (dealer != null)
            {
                dealerHand = dealer.Hand;
            }
            if (result == "Black Jack")
            {
                db.DbInsert("Win", gamerHand, dealerHand);
                db.DbUpdate("StatResult", 1);
                db.DbUpdate("StatResult", 2);
            }
            else if (result == "Win")
            {
                db.DbInsert("Win", gamerHand, dealerHand);
                db.DbUpdate("StatResult", 2);
            }
            else if (result == "Bust")
            {
                db.DbInsert("Lose", gamerHand, dealerHand);
                db.DbUpdate("StatResult", 3);
                db.DbUpdate("StatResult", 4);
            }
            else if (result == "Lose")
            {
                db.DbInsert("Lose", gamerHand, dealerHand);
                db.DbUpdate("StatResult", 4);
            }
            else
            {
                db.DbInsert("Push", gamerHand, dealerHand);
                db.DbUpdate("StatResult", 5);
            }
        }
        public static void InsertStat(string card)
        {
            int key = 0;
            string value = null;
            foreach (char i in card)
            {
                if(i != ' ')
                {
                    value += i;
                }
                else if(value != null)
                {
                    if (value.Length > 0 && value.Length <= 2)
                    {
                        switch (value)
                        {
                            case "A": key = 1; break;
                            case "J": key = 11; break;
                            case "D": key = 12; break;
                            case "K": key = 13; break;
                            default: key = int.Parse(value); break;
                        }
                        bd.DbUpdate("CardsValue", key);
                    }
                    else
                    {
                        switch (value)
                        {
                            case "Diamonds": key = 1; break;
                            case "Hearts": key = 2; break;
                            case "Spades": key = 3; break;
                            case "Clubs": key = 4; break;
                            default: break;
                        }
                        bd.DbUpdate("CardsLear", key);
                    }
                    value = null;
                }
            }
        }
        public void DbUpdate()
        {
            db.DbUpdate();
        }
        public string StatDB()
        {
            string a = null;
            a += db.DbStat("CardsLear");
            a += db.DbStat("CardsValue");
            a += db.DbStat("StatResult");
            return a;
            //Console.WriteLine("What game number are you want to see?");
            //int a = 0;
            //int.TryParse(Console.ReadLine(), out a);
            //db.DbStat(a);
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
        string ShowHands(Gamer who)
        {
            string str = who.GetType() == typeof(Gamer) ? "Your" : "Dealers";
            Console.WriteLine($"{str} hand: {who.Hand}, sum: {who.Sum}");
            return $"{str} hand: {who.Hand}, sum: {who.Sum}";
        }
        public static string TakeCardFromDeck()
        {
            string card = deck.GetCard();
            task = Task.Factory.StartNew(() => InsertStat(card));
            //InsertStat(card);
            return card;
        }

        public string Play()
        {
            deck = new CardDeck();
            gamer = new Gamer();
            gamer.TakeCard();
            ShowHands(gamer);
            if (gamer.Sum == 21)
            {
                Console.WriteLine("Black Jack, You WIN!");
                task = Task.Factory.StartNew(() => StatInsert("Black Jack"));
                //StatInsert("Black Jack");
                Console.ReadKey();
                return "Black Jack, You WIN!";
            }
            else
            {
                string a = null;
                bool flag = false;
                do
                {
                    if(flag)
                    {
                        gamer.TakeCard();
                        a = ShowHands(gamer);
                    }
                    if (gamer.Sum > 21)
                    {
                        Console.WriteLine("Bust! You lose");
                        task = Task.Factory.StartNew(() => StatInsert("Bust"));
                        //StatInsert("Bust");
                        a += "Bust! You lose";
                        break;
                    }
                    else if (gamer.Sum == 21)
                    {
                        a += "Stop";
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
                        task = Task.Factory.StartNew(() => StatInsert("Win"));
                        //StatInsert("Win");
                        a += "You win!";
                    }
                    else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Dealer wins, you lose");
                        task = Task.Factory.StartNew(() => StatInsert("Lose"));
                        //StatInsert("Lose");
                        a += "Dealer wins, you lose";
                    }
                    else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("You Win!");
                        task = Task.Factory.StartNew(() => StatInsert("Win"));
                        //StatInsert("Win");
                        a += "You Win!";
                    }
                    else
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Push!");
                        task = Task.Factory.StartNew(() => StatInsert("Push"));
                        //StatInsert("Push");
                        a += "Push!";
                    }
                }
                return a;
            }
        }
    }
}
