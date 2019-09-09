using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using IBlackJack;

namespace BlackJack
{
    public class BlackJack
    {
        static CardDeck deck = new CardDeck();
        Gamer gamer = new Gamer();
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
                if (i != ' ')
                {
                    value += i;
                }
                else if (value != null)
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

        internal string[][] Stat() // 4.
        {
            string[][] stat = new string[3][];
            stat.Append(db.DbStat("CardsLear"));
            stat.Append(db.DbStat("CardsValue"));
            stat.Append(db.DbStat("StatResult"));
            return stat;
        }

        //internal void Replay(bool b) //5.
        //{
        //    if (b) S();
        //}

        string ShowHands(Gamer who)
        {
            return $"{who.Hand}";
        }

        public string ShowHands()
        {
            return $"{gamer.Hand}";
        }

        public static int TakeCardFromDeck()
        {
            int card = deck.GetCard();
            //task = Task.Factory.StartNew(() => InsertStat(card));
            return card;
        }

        internal string Start() //1.
        { 
            gamer.TakeCard();
            gamer.TakeCard();
            if (gamer.Sum == 21)
            {
                //task = Task.Factory.StartNew(() => StatInsert("Black Jack"));
                return ShowHands(gamer) + " 53";
            }
            return ShowHands(gamer);
        }

        internal string Answer(out bool b)
        {
            string c = null;
            c += gamer.TakeCard();
            if (gamer.Sum > 21)
            {
                //task = Task.Factory.StartNew(() => StatInsert("Bust"));
                b = false;
                return c + " 54";
            }
            else if (gamer.Sum == 21)
            {
                dealer = new Dealer();
                dealer.DealerPlay();
                if (dealer.Sum > 21)
                {
                    //task = Task.Factory.StartNew(() => StatInsert("Win"));
                    b = false;
                    return c + " D " + ShowHands(dealer) + " 55";
                }
                else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                {
                    //task = Task.Factory.StartNew(() => StatInsert("Lose"));
                    b = false;
                    return c + " D " + ShowHands(dealer) + " 56";
                }
                else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                {
                    //task = Task.Factory.StartNew(() => StatInsert("Win"));
                    b = false;
                    return c + " D " + ShowHands(dealer) + " 55";
                }
                else
                {
                    //task = Task.Factory.StartNew(() => StatInsert("Push"));
                    b = false;
                    return c + " D " + ShowHands(dealer) + " 57";
                }
            }
            else
            {
                b = true;
                return c + " 58";
            }
        }

        internal string Answer()
        {
            dealer = new Dealer();
            dealer.DealerPlay();
            if (dealer.Sum > 21)
            {
                //task = Task.Factory.StartNew(() => StatInsert("Win"));
                return "D " + ShowHands(dealer) + " 55";
            }
            else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
            {
                //task = Task.Factory.StartNew(() => StatInsert("Lose"));
                return "D " + ShowHands(dealer) + " 56";
            }
            else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
            {
                //task = Task.Factory.StartNew(() => StatInsert("Win"));
                return "D " + ShowHands(dealer) + " 55";
            }
            else
            {
                //task = Task.Factory.StartNew(() => StatInsert("Push"));
                return "D " + ShowHands(dealer) + " 57";
            }
        }

        //internal string Play(bool b) //2.
        //{
        //    string c = null;
        //    if (b)
        //    {
        //        c += gamer.TakeCard();
        //        if (gamer.Sum > 21)
        //        {
        //            //task = Task.Factory.StartNew(() => StatInsert("Bust"));
        //            return c + " 54";
        //        }
        //        else if (gamer.Sum == 21)
        //        {
        //            dealer = new Dealer();
        //            dealer.DealerPlay();
        //            if (dealer.Sum > 21)
        //            {
        //                //task = Task.Factory.StartNew(() => StatInsert("Win"));
        //                return c + " D " + ShowHands(dealer) + " 55";
        //            }
        //            else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
        //            {
        //                //task = Task.Factory.StartNew(() => StatInsert("Lose"));
        //                return c + " D " + ShowHands(dealer) + " 56";
        //            }
        //            else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
        //            {
        //                //task = Task.Factory.StartNew(() => StatInsert("Win"));
        //                return c + " D " + ShowHands(dealer) + " 55";
        //            }
        //            else
        //            {
        //                //task = Task.Factory.StartNew(() => StatInsert("Push"));
        //                return c + " D " + ShowHands(dealer) + " 57";
        //            }
        //        }
        //        else
        //        {
        //            return c + " 58";
        //        }
        //    }
        //    else
        //    {
        //        dealer = new Dealer();
        //        dealer.DealerPlay();
        //        if (dealer.Sum > 21)
        //        {
        //            //task = Task.Factory.StartNew(() => StatInsert("Win"));
        //            return c + " D " + ShowHands(dealer) + " 55";
        //        }
        //        else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
        //        {
        //            //task = Task.Factory.StartNew(() => StatInsert("Lose"));
        //            return c + " D " + ShowHands(dealer) + " 56";
        //        }
        //        else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
        //        {
        //            //task = Task.Factory.StartNew(() => StatInsert("Win"));
        //            return c + " D " + ShowHands(dealer) + " 55";
        //        }
        //        else
        //        {
        //            //task = Task.Factory.StartNew(() => StatInsert("Push"));
        //            return c + " D " + ShowHands(dealer) + " 57";
        //        }
        //    }
        //}

        internal bool Exit() //3.
        {
            db.DbClose();
            return true;
        }

        /*
        public void Play()
        {
            deck = new CardDeck();
            gamer = new Gamer();
            gamer.TakeCard();
            //ShowHands(gamer);
            if (gamer.Sum == 21)
            {
                //Console.WriteLine("Black Jack, You WIN!");
                task = Task.Factory.StartNew(() => StatInsert("Black Jack"));
                //ShowHands(gamer) + " Black Jack, You WIN!";
                //StatInsert("Black Jack");
                //Console.ReadKey();
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
                        task = Task.Factory.StartNew(() => StatInsert("Bust"));
                        //StatInsert("Bust");
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
                        task = Task.Factory.StartNew(() => StatInsert("Win"));
                        //StatInsert("Win");
                    }
                    else if (dealer.Sum <= 21 && dealer.Sum > gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Dealer wins, you lose");
                        task = Task.Factory.StartNew(() => StatInsert("Lose"));
                        //StatInsert("Lose");
                    }
                    else if (dealer.Sum < 21 && dealer.Sum < gamer.Sum)
                    {
                        ShowHands(dealer);
                        Console.WriteLine("You Win!");
                        task = Task.Factory.StartNew(() => StatInsert("Win"));
                        //StatInsert("Win");
                    }
                    else
                    {
                        ShowHands(dealer);
                        Console.WriteLine("Push!");
                        task = Task.Factory.StartNew(() => StatInsert("Push"));
                        //StatInsert("Push");
                    }
                }
            }
        } */
    }
}
