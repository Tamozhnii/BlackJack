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

        public void DbInsert(string tab, string key)
        {
            SQLiteCommand CMD = db.CreateCommand();
            int a = int.Parse(CMD.CommandText = $"select Count from {tab} where ID = {key}");
            int total = int.Parse(CMD.CommandText = $"select Count from {tab} where ID = TOTAL");
            a++;
            total++;
            int p = a / total * 100;
            CMD.CommandText = $"insert into {tab}(Count) where ID = {key} values('{a}')";
            CMD.CommandText = $"insert into {tab}(Count) where ID = TOTAL values('{total}')";
            CMD.CommandText = $"insert into {tab}(Percent) where ID = {key} values('{p}')";
            CMD.ExecuteNonQuery();
        }

        public void DbInsert(string result, string gamerHand, string dealerHand)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"insert into GameRezult(Result, Hand, Dealer) values('{result}','{gamerHand}','{dealerHand}')";
            CMD.ExecuteNonQuery();
        }

        public void DbStat(string tab)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"select * from {tab}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            while (Stat.Read())
            {
                Console.WriteLine(Stat["ID"] + ": " + Stat["Count"] + ", " + Stat["Percent"] + " %");
            }
        }

        public void DbStat(int id)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"select * from GameRezult where ID = {id}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            Console.WriteLine("Game " + Stat["ID"] + ": " + "Result: " + Stat["Result"] + "\n" + "Your hand: " + Stat["Hand"] + "\n" + "Dealer hand" + Stat["Dealer"]);
        }
    }
}
