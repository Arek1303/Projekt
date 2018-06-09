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
        public List<List<string>> WczytajRekordy(string tabela, List<string> nazwyKolumn)
        {
            //Nawiązanie połączenia z bazą danych
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                List<List<string>> listaRekordow = new List<List<string>>();
                List<string> listaWartosci = new List<string>();
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                int ilosc = nazwyKolumn.Count();

                string query = @"SELECT " + nazwyKolumn[0];
                if (ilosc > 1)
                {
                    for (int i = 1; i < ilosc; i++)
                    {
                        query += "," + nazwyKolumn[i];
                    }
                }
                query+= " FROM " + tabela;

                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int liczbaZmiennych = read.FieldCount;
                    for (int i = 0; i < liczbaZmiennych; i++)
                    {
                        Type t = typeof(System.Int64);
                        Type d = typeof(System.DateTime);


                        if (read.GetFieldType(i).Equals(t))
                        {
                            listaWartosci.Add(read.GetFieldValue<long>(i).ToString());
                        }
                        else if(read.GetFieldType(i).Equals(d))
                        {
                            listaWartosci.Add(read.GetFieldValue<DateTime>(i).ToString());
                        }
                        else
                        {
                            listaWartosci.Add(read.GetFieldValue<string>(i));
                        }              
                    }
                    listaRekordow.Add(listaWartosci);
                    listaWartosci = new List<string>();
                }
                return listaRekordow;
            }
        }
        // Metoda obsługująca wczytanie rekordów z bazy danych
        public List<List<string>> WczytajRekordy(string tabela, List<string> nazwyKolumn, string warunki)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                List<List<string>> listaRekordow = new List<List<string>>();
                List<string> listaWartosci = new List<string>();
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                int ilosc = nazwyKolumn.Count();

                string query = @"SELECT " + nazwyKolumn[0];
                if (ilosc > 1)
                {
                    for (int i = 1; i < ilosc; i++)
                    {
                        query += "," + nazwyKolumn[i];
                    }
                }
                query += " FROM " + tabela;
                query += " WHERE " + warunki;

                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int liczbaZmiennych = read.FieldCount;
                    for (int i = 0; i < liczbaZmiennych; i++)
                    {
                        Type t = typeof(System.Int64);
                        Type d = typeof(System.DateTime);
                        if (read.GetFieldType(i).Equals(t))
                        {
                            listaWartosci.Add(read.GetFieldValue<long>(i).ToString());
                        }
                        else if (read.GetFieldType(i).Equals(d))
                        {
                            listaWartosci.Add(read.GetFieldValue<DateTime>(i).ToString());
                        }
                        else
                        {
                            listaWartosci.Add(read.GetFieldValue<string>(i));
                        }

                    }
                    listaRekordow.Add(listaWartosci);
                    listaWartosci = new List<string>();
                }

                return listaRekordow;
            }

        }
        // Metoda obsługująca edycja zawartości rekordów bazy danych
        public void WyslijUpdate(List<string> dane, string tabela)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"UPDATE " + tabela + " SET " + dane[1];
                if (dane.Count > 2)
                {
                    for (int i = 2; i < dane.Count; i++)
                    {
                        query += ", " +dane[i];
                    }
                }
                query += " WHERE " + dane[0];
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
        // Metoda wstawiająca nowe dane do bazy danych
        public void WyslijNoweDane(List<string> dane, string tabela)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"INSERT INTO " + tabela + " VALUES (" + "'"+ dane[0] + "'";
                if (dane.Count > 1)
                {
                    for (int i = 1; i < dane.Count; i++)
                    {
                        query += ", " + "'" + dane[i] + "'";
                    }
                }
                query += ")";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
        //Metoda obsługująca usuwanie rekordów z bazy danych
        public void UsunDane(string warunek, string tabela)
        {
            var auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"DELETE FROM " + tabela + " WHERE " + warunek;

                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
