using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BlackJack
{
    public class BJDB
    {
        SQLiteConnection db;
        
        public BJDB()
        {
            db = new SQLiteConnection("Data Source = BJDB.db; Version = 3");
            db.Open();
        }

        public void DbClose()
        {
            db.Close();
        }

        public void DbUpdate(string tab, int key)
        {
            SQLiteCommand CMD = db.CreateCommand();
            string updateCount = $"UPDATE {tab} SET Count = (Count + 1) WHERE ID = {key}";
            string updateTotal = $"UPDATE {tab} SET Count = (Count + 1) WHERE ID = 20";
            CMD.CommandText = updateCount;
            CMD.ExecuteNonQuery();
            CMD.CommandText = updateTotal;
            CMD.ExecuteNonQuery();
        }

        public void DbUpdate()
        {
            SQLiteCommand CMD = db.CreateCommand();
            for (int i = 1; i < 5; i++)
            {
                string updatePercent = $"UPDATE CardsLear SET Percent = (100 * (SELECT \"Count\" FROM CardsLear WHERE ID = {i}) / (SELECT \"Count\" FROM CardsLear WHERE ID = 20)) WHERE ID = {i}";
                CMD.CommandText = updatePercent;
                CMD.ExecuteNonQuery();
            }
            for (int j = 1; j < 14; j++)
            {
                string updatePercent = $"UPDATE CardsValue SET Percent = (100 * (SELECT \"Count\" FROM CardsValue WHERE ID = {j}) / (SELECT \"Count\" FROM CardsValue WHERE ID = 20)) WHERE ID = {j}";
                CMD.CommandText = updatePercent;
                CMD.ExecuteNonQuery();
            }
            for (int g = 1; g <= 5; g++)
            {
                string updatePercent = $"UPDATE StatResult SET Percent = (100 * (SELECT \"Count\" FROM StatResult WHERE ID = {g}) / (SELECT \"Count\" FROM StatResult WHERE ID = 20)) WHERE ID = {g}";
                CMD.CommandText = updatePercent;
                CMD.ExecuteNonQuery();
            }
        }

        public void DbInsert(string result, string gamerHand, string dealerHand)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"INSERT INTO GameRezult(Result, Hand, Dealer) VALUES('{result}','{gamerHand}','{dealerHand}')";
            CMD.ExecuteNonQuery();
        }

        public void DbStat(string tab)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"SELECT * FROM {tab}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            while (Stat.Read())
            {
                Console.WriteLine(Stat[0] + ".\t" + Stat[1] + ":\t" + Stat[2] + ",\t" + Stat[3] + " %");
            }
            Stat.Close();
            Console.WriteLine();
        }

        public void DbStat(int id)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"SELECT * FROM GameRezult WHERE ID = {id}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            while (Stat.Read())
            {
                Console.WriteLine("Game " + Stat[0] + ": \t" + "Result: " + Stat[1] + "\n" + "Your hand: \t" + Stat[2] + "\n" + "Dealer hand: \t" + Stat[3]);
            }
            Stat.Close();
        }
    }
}
