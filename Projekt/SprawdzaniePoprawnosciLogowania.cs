using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{   // Sprawdzanie poprawności zalogowanego użytkownika
    class CheckLogin : IInterfejsLogowania
    {
        // Sprawdzanie poprawności dla pacjenta
        public int CheckPatient(string username, string password)
        {
            //Nawiązanie połączenia z bazą danych
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                long NumerID = 0;
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"SELECT * FROM Pacjent WHERE Login='" + username + "' and Haslo='" + password + "'";
                int count = 0;
                cmd.CommandText = query;
                cmd.Connection = con;
                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    count++;
                    NumerID = read.GetFieldValue<Int64>(0);
                }
                if (count == 1)
                {
                    return (int)NumerID;
                }
                else
                { 
                    return 0;
                }
            }
        }
        // SWprawdzanie poprawnosci logowania dla lekarza
        public int ChecKDoctor(string username, string password)
        {
            //Nawiązanie połączenia z bazą danych
            var auth = new Authentication();
            auth.getConnection();
            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                long NumerID = 0;
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"SELECT * FROM Lekarz WHERE Login='" + username + "' and Haslo='" + password + "'";

                int count = 0;
                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    count++;
                    NumerID = read.GetFieldValue<Int64>(0);
                }
                if (count == 1)
                {
                    return (int)NumerID;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
