using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{

    public partial class Logowanie : Form
    {
        private SprawdzaniePoprawnosciLogowania tester = new SprawdzaniePoprawnosciLogowania();
        // Wywołanie panelu logowania
        public Logowanie()
        {
            InitializeComponent();
            //Ukrycie hasła logowania
            txtPassword.UseSystemPasswordChar = true;
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }
        // Wywołanie powrotu to początkowego panelu
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
            
        }
        //Wywołanie logowania do systemu
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != string.Empty && txtPassword.Text != string.Empty)
            {
                // Sprawdzenie logowania jako pacjent
                var numerID = tester.sprawdzPacjent(txtLogin.Text, txtPassword.Text);
                if (numerID != 0)
                {
                    this.Hide();
                    WczytywanieZBazy wczytaj = new WczytywanieZBazy();
                    List<string> pacjent = new List<string>();
                    List<string> tabele = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Wiek","Login", "Haslo"
                    };
                    string warunek = "ID='" + numerID + "'";
                    pacjent = wczytaj.WczytajRekordy("Pacjent", tabele, warunek)[0];

                    EkranGlownyPacjenta ekranPacjent = new EkranGlownyPacjenta(pacjent);
                    ekranPacjent.Show();
                }
                else
                {
                    //Sprawdzenie logowania jako lekarz
                    numerID = tester.sprawdzLekarz(txtLogin.Text, txtPassword.Text);
                    if (numerID != 0)
                    {
                        this.Hide();
                        WczytywanieZBazy wczytaj = new WczytywanieZBazy();
                        List<string> lekarz = new List<string>();
                        List<string> tabele = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Specjalizacja","Login", "Haslo"
                    };
                        string warunek = "ID='" + numerID + "'";
                        lekarz = wczytaj.WczytajRekordy("Lekarz", tabele, warunek)[0];

                        EkranGlownyLekarza ekranLekarz = new EkranGlownyLekarza(lekarz);
                        ekranLekarz.Show();
                    }
                    else
                    {
                        MessageBox.Show("Błędny Login lub Hasło!", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                
                
            }
        }
    }
}
