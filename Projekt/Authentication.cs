using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

public class Authentication
{
    public string connectionString { get; set; }
    string connection;

    // Metoda nawiązująca połączenie z bazą danych
    public void getConnection()
    {
        connection = @"Data Source=BazaDanych.db; Version=3";
        connectionString = connection;
    }
        /*
        public void createDatabase()
        {
            if (!File.Exists("Baza.db"))
            {
                File.Create("Baza.db");
                createTable();
            }
            /*
            else
            {
                createTable();
            }
        }
        private void createTable()
        {
            getConnection();
            using (SQLiteConnection con = new SQLiteConnection(connection))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();


                string query = @"CREATE TABLE USERS ( ID INTEGER PRIMARY KEY AUTOINCREMENT, name Text(25), surname Text(25),login Text(25),password Text(25))";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }*/
}

