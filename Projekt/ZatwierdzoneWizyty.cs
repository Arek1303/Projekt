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
    // Panel obsługujący wyświetlenie informacji pacjentowi wraz z ich statusem
    public partial class ZatwierdzoneWizyty : Form
    {
        // Połączenie z bazą danych i wczytanie wizyt danego pacjenta
        public ZatwierdzoneWizyty(string idpacjent)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;

            List<List<string>> informacjeoWizycie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> wizyta = new List<string>();
            string warunek = "IdPacjent='" + idpacjent + "'";
            List<string> tabele = new List<string>
            {
                "ID", "DataWizyty", "Godzina","Status"
            };
            // Edycja wczytanych danych w celu przygotowania widoku dla pacjenta
            informacjeoWizycie = wczytaj.WczytajRekordy("Wizyta", tabele,warunek);
            foreach (var item in informacjeoWizycie)
            {
                var status = item[3];
                if (status == "0")
                {
                    status = "Nieprzetworzone";
                }
                else if (status == "1")
                {
                    status = "Zatwierdzony";
                }
                else if(status == "2")
                {
                    status = "Odrzucony";
                }
                else if(status == "3")
                {
                    status = "Odbyte";
                }

                dataGridView1.Rows.Add(item[1].Substring(0,10), item[2].Remove(0,11), status);
            }
        }
        //Powrót do panelu głównego
        private void label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }


    }
}
