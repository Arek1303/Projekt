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

    // Wywołanie panelu zarządzania pacjentami
    public partial class CrudPacjent : Form
    {
        public CrudPacjent()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            MetodaWczytania();

        }
        // Wczytanie listy pacjentów
        public void MetodaWczytania()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> informacjeopacjencie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> pacjent = new List<string>();
            List<string> tabele = new List<string>
            {
                "ID", "Imie", "Nazwisko", "Wiek"
            };
            informacjeopacjencie = wczytaj.WczytajRekordy("Pacjent", tabele);
            foreach (var item in informacjeopacjencie)
            {
                dataGridView1.Rows.Add(item[0], item[1], item[2], item[3]);
            }
        }
        // Usuwanie wybranego pacjenta
        private void button1_Click(object sender, EventArgs e)
        {
            string idusuwanego = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            wczytaj.UsunDane("id = '" + idusuwanego + "'", "Pacjent");
            MetodaWczytania();
        }
        // Powrót do menu głownego
        private void CrudPacjent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
