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
    public partial class Oferta : Form
    {
        // Wywołanie panelu ofert dla pacjenta i wczytanie ofert z bazy danych
        public Oferta()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(698, 382);
            this.MaximumSize = new Size(698, 382);
            this.MaximizeBox = false;
            List<List<string>> informacjeoOfercie;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> aktualnosc = new List<string>();
            List<string> tabele = new List<string>
            {
                "ID", "Nazwa", "Opis", "Cena"
            };
            informacjeoOfercie = wczytaj.WczytajRekordy("Oferta", tabele);
            foreach (var item in informacjeoOfercie)
            {
                dataGridView1.Rows.Add(item[1], item[2], item[3]);
            }      
        }
        // Powrót do głównego panelu pacjenta
        private void label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
