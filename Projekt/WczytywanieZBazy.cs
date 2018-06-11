using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
   public class WczytywanieZBazy
    {
        // Klasa zawierająca metody obsługujące operacje na bazie danych
        public List<List<string>> LoadData(string table, List<string> columnsName)
        {
            //Nawiązanie połączenia z bazą danych
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                List<List<string>> RecordsList = new List<List<string>>();
                List<string> ValueList = new List<string>();
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                int Count = columnsName.Count();

                string query = @"SELECT " + columnsName[0];
                if (Count > 1)
                {
                    for (int i = 1; i < Count; i++)
                    {
                        query += "," + columnsName[i];
                    }
                }
                query+= " FROM " + table;

                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int VariableCount = read.FieldCount;
                    for (int i = 0; i < VariableCount; i++)
                    {
                        Type t = typeof(System.Int64);
                        Type d = typeof(System.DateTime);


                        if (read.GetFieldType(i).Equals(t))
                        {
                            ValueList.Add(read.GetFieldValue<long>(i).ToString());
                        }
                        else if(read.GetFieldType(i).Equals(d))
                        {
                            ValueList.Add(read.GetFieldValue<DateTime>(i).ToString());
                        }
                        else
                        {
                            ValueList.Add(read.GetFieldValue<string>(i));
                        }              
                    }
                    RecordsList.Add(ValueList);
                    ValueList = new List<string>();
                }
                return RecordsList;
            }
        }
        // Metoda obsługująca wczytanie rekordów z bazy danych
        public List<List<string>> LoadData(string table, List<string> columnsName, string conditions)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                List<List<string>> RecordsList = new List<List<string>>();
                List<string> ValueList = new List<string>();
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                int count = columnsName.Count();

                string query = @"SELECT " + columnsName[0];
                if (count > 1)
                {
                    for (int i = 1; i < count; i++)
                    {
                        query += "," + columnsName[i];
                    }
                }
                query += " FROM " + table;
                query += " WHERE " + conditions;

                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int VariableCount = read.FieldCount;
                    for (int i = 0; i < VariableCount; i++)
                    {
                        Type t = typeof(System.Int64);
                        Type d = typeof(System.DateTime);
                        if (read.GetFieldType(i).Equals(t))
                        {
                            ValueList.Add(read.GetFieldValue<long>(i).ToString());
                        }
                        else if (read.GetFieldType(i).Equals(d))
                        {
                            ValueList.Add(read.GetFieldValue<DateTime>(i).ToString());
                        }
                        else
                        {
                            ValueList.Add(read.GetFieldValue<string>(i));
                        }

                    }
                    RecordsList.Add(ValueList);
                    ValueList = new List<string>();
                }

                return RecordsList;
            }

        }
        // Metoda obsługująca edycja zawartości rekordów bazy danych
        public void SendUpdate(List<string> date, string table)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"UPDATE " + table + " SET " + date[1];
                if (date.Count > 2)
                {
                    for (int i = 2; i < date.Count; i++)
                    {
                        query += ", " +date[i];
                    }
                }
                query += " WHERE " + date[0];
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
        // Metoda wstawiająca nowe dane do bazy danych
        public void SendData(List<string> date, string table)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"INSERT INTO " + table + " VALUES (" + "'"+ date[0] + "'";
                if (date.Count > 1)
                {
                    for (int i = 1; i < date.Count; i++)
                    {
                        query += ", " + "'" + date[i] + "'";
                    }
                }
                query += ")";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
        //Metoda obsługująca usuwanie rekordów z bazy danych
        public void DeleteData(string condition, string table)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"DELETE FROM " + table + " WHERE " + condition;

                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
