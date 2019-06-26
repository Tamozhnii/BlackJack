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

        public void DbInsert(string tab, int key)
        {
            SQLiteCommand CMD = db.CreateCommand();
            string selectID = $"UPDATE {tab} SET Count = Count + 1, Perce WHERE ID = {key}";
            string selectTotal = $"SELECT Count FROM {tab} WHERE ID = 20";
            //int a;
            using(SQLiteCommand command = new SQLiteCommand(selectID, db))
            {
                //a = int.Parse(command.ExecuteScalar().ToString());
            }
            //int total;
            using (SQLiteCommand command = new SQLiteCommand(selectTotal, db))
            {
                //total = int.Parse(command.ExecuteScalar().ToString());
            }
            //a++;
            //total++;
            //int p = a / total * 100;
            //CMD.CommandText = $"UPDATE {tab} SET Count = {a}, Percent = {p} WHERE ID = {key}";
            //CMD.CommandText = $"UPDATE { tab} SET Count = { total } WHERE ID = 20";
            //CMD.ExecuteNonQuery();
            //CMD.CommandText = $"UPDATE {tab} SET Count = {total} WHERE ID = 20";
            //CMD.ExecuteNonQuery();
            //CMD.CommandText = $"UPDATE {tab} SET Percent = {p} WHERE ID = {key}";
            //CMD.ExecuteNonQuery();
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
                Console.WriteLine(Stat[0] + ". " + Stat[1] + ": " + Stat[2] + ", " + Stat[3] + " %");
            }
            Stat.Close();
            Console.WriteLine();
        }

        public void DbStat(int id)
        {
            SQLiteCommand CMD = db.CreateCommand();
            CMD.CommandText = $"SELECT * FROM GameRezult WHERE ID = {id}";
            SQLiteDataReader Stat = CMD.ExecuteReader();
            Console.WriteLine("Game " + Stat[0] + ": " + "Result: " + Stat[1] + "\n" + "Your hand: " + Stat[2] + "\n" + "Dealer hand" + Stat[3]);
            Stat.Close();
        }
    }
}
