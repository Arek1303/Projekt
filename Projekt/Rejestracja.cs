using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Projekt
{
    public partial class Registration : Form
    {
        // Wywołanie Panelu Rejestracji
        public Registration()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;

        }
        // Wywołanie powrotu do początkowego panelu
        private void Label6_Click(object sender, EventArgs e) // Strzałka powrotu
        {
            this.Dispose();
            Form1 form = new Form1();
            form.Show();
        }

        //Wywołanie rejestracji do systemu
        Authentication auth;
        private void Button1_Click(object sender, EventArgs e) //Register Button
        {
            if (name.Text != string.Empty &&
               surname.Text != string.Empty &&
               login.Text != string.Empty &&
               password.Text != string.Empty
                )
            {
                CheckAccount(name.Text);
            }
        }
        // Sprawdzenie istniejącego konta
        private void CheckAccount(string username)
        {
            auth = new Authentication();
            auth.getConnection();
            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                con.Open();
                int count = 0;
                string query = @"SELECT * FROM Pacjent WHERE Login='" + username +"'";
                cmd.CommandText = query;
                cmd.Connection = con;
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MessageBox.Show("Juz istnieje", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (count == 0)
                {
                    InsertData(name.Text, surname.Text, login.Text, password.Text, age.Text);
                }
            }
        }
        // Metoda wstawiająca dane do bazy, wywoływana w przypadku pomyślnego przejścia przez panel rejestracji
        private void InsertData(string names, string surnames, string logins, string passwords, string ages )
        {
            // Nawiązanie połączenia z bazą danych
            auth = new Authentication();
            auth.getConnection();     
            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"Insert INTO Pacjent(Imie,Nazwisko,Login,Haslo,Wiek) VALUES (@name , @surname, @login , @password, @age)";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.Add(new SQLiteParameter("@name", names));
                cmd.Parameters.Add(new SQLiteParameter("@surname", surnames));
                cmd.Parameters.Add(new SQLiteParameter("@login", logins));
                cmd.Parameters.Add(new SQLiteParameter("@password", passwords));
                cmd.Parameters.Add(new SQLiteParameter("@age", ages));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Zostałeś zarejestrowany, przejdź do panelu logowania", "ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
