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
    public partial class CrudAktualizacja : Form
    {
        //Wywołanie panelu zarządzania aktualizacjami
        public CrudAktualizacja()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(684, 382);
            this.MaximumSize = new Size(684, 382);
            this.MaximizeBox = false;
            MetodaWczytania();
        }
        // Połączenie z bazą i wczytanie aktualności
        public void MetodaWczytania()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> informacjeopacjencie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> pacjent = new List<string>();
            List<string> tabele = new List<string>
            {
                "ID", "Tytul", "Opis", "Data"
            };
            informacjeopacjencie = wczytaj.WczytajRekordy("Aktualnosc", tabele);
            foreach (var item in informacjeopacjencie)
            {
                dataGridView1.Rows.Add(item[0], item[1], item[2], item[3].Substring(0, 10));
            }
        }
        // Metoda usuwania aktualności
        private void btnUsun_Click(object sender, EventArgs e)
        {
            string idusuwanego = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            wczytaj.UsunDane("id = '" + idusuwanego + "'", "Aktualnosc");
            MetodaWczytania();
        }
        // Metoda dodawania aktualności
        private void btnDodaj_Click(object sender, EventArgs e)
        { 
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> dane = new List<string> { txtTytul.Text,txtOpis.Text, DateTime.Now.ToString("yyyy-MM-dd")};
            wczytaj.WyslijNoweDane(dane, "Aktualnosc (Tytul,Opis,Data)");
            MetodaWczytania();
        }
        // Metoda powrotu do panelu głównego
        private void CrudAktualizacja_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }

}
