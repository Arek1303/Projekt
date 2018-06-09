using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    //Wywołanie panelu zarządzania wizytami
    public partial class CrudWizyty : Form
    {
        public CrudWizyty()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            MetodaWczytania();
        }
        //Wczytanie wizyt i wyświetlenie ich wraz z odpowiednimi statusami
        public void MetodaWczytania()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> informacjeOWizycie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> pacjent = new List<string>();
            List<string> tabele = new List<string>
            {
                "ID", "IdPacjent", "DataWizyty", "Godzina", "Status"
            };
            informacjeOWizycie = wczytaj.WczytajRekordy("Wizyta", tabele);

            foreach (var item in informacjeOWizycie)
            {
                var status = item[4];
                if (status == "0")
                {
                    status = "Nieprzetworzone";
                }
                else if (status == "1")
                {
                    status = "Zatwierdzony";
                }
                else if (status == "2")
                {
                    status = "Odrzucony";
                }
                else if (status == "3")
                {
                    status = "Odbyte";
                }
                var imieOrazNazwisko = WczytajImieOrazNazwiskoPacjenta(item[1]);
                dataGridView1.Rows.Add(item[0], imieOrazNazwisko, item[2].Substring(0, 10), item[3].Remove(0, 11), status);
            }
        }
        // Metoda zmieniająca status wizyty
        private void btnZmien_Click(object sender, EventArgs e)
        {
            string wybierzS = WybierzStatus();
            string idZmienianego = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            string warunek = "id='" + idZmienianego + "'";
            List<string> dane = new List<string> { warunek, "Status='" + wybierzS + "'" };
            wczytaj.WyslijUpdate(dane, "Wizyta ");
            MetodaWczytania();
        }
        // Modyfikacja w celu czytelności informacji
        private string WybierzStatus()
        {
            if ((string)comboBox1.SelectedItem == "Zatwierdzony")
            {
                return "1";
            }
            else if ((string)comboBox1.SelectedItem == "Odrzucony")
            {
                return "2";
            }
            else if ((string)comboBox1.SelectedItem == "Odbyte")
            {
                return "3";
            }
            else
            {
                return "0";
            }
        }
        public string WczytajImieOrazNazwiskoPacjenta(string id)
        {
            List<List<string>> informacjeopacjencie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> pacjent = new List<string>();
            List<string> tabele = new List<string>
            {
                "Imie", "Nazwisko"
            };
            informacjeopacjencie = wczytaj.WczytajRekordy("Pacjent", tabele, "id='" + id + "'");
            if (informacjeopacjencie.Count != 0)
            {
                return informacjeopacjencie[0][0] + " " + informacjeopacjencie[0][1];
            }
            else
            {
                return "Taki pacjent już nie istnieje";
            }

        }
        // Powrót do menu głównego
        private void CrudWizyty_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
