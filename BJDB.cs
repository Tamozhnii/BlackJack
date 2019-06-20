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
            db = new SQLiteConnection("Data Source = BJDB.db; Version = 0");
            db.Open();
        }

        public void DbClose()
        {
            db.Close();
        }

        public void DbInsert(string tab, string key)
        {
            SQLiteCommand CMD = db.CreateCommand();
            int a = int.Parse(CMD.CommandText = $"SELECT Count FROM {tab} WHERE ID = {key}");
            int total = int.Parse(CMD.CommandText = $"SELECT Count FROM {tab} WHERE ID = TOTAL");
            a++;
            total++;
            int p = a / total * 100;
            CMD.CommandText = $"INSERT INTO {tab}(Count) WHERE ID = {key} VALUES('{a}')";
            CMD.CommandText = $"INSERT INTO {tab}(Count) WHERE ID = TOTAL VALUES('{total}')";
            CMD.CommandText = $"INSERT INTO {tab}(Percent) WHERE ID = {key} VALUES('{p}')";
            CMD.ExecuteNonQuery();
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
                Console.WriteLine(Stat["ID"] + ": " + Stat["Count"] + ", " + Stat["Percent"] + " %");
            }
        }

        public void DbStat(int id)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"SELECT * FROM GameRezult WHERE ID = {id}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            Console.WriteLine("Game " + Stat["ID"] + ": " + "Result: " + Stat["Result"] + "\n" + "Your hand: " + Stat["Hand"] + "\n" + "Dealer hand" + Stat["Dealer"]);
        }
    }
}
