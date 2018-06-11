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
    public partial class Offer : Form
    {
        // Wywołanie panelu ofert dla pacjenta i wczytanie ofert z bazy danych
        public Offer()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(698, 382);
            this.MaximumSize = new Size(698, 382);
            this.MaximizeBox = false;
            List<List<string>> OfferInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Offer = new List<string>();
            List<string> Collumns = new List<string>
            {
                "ID", "Nazwa", "Opis", "Cena"
            };
            OfferInformation = Load.LoadData("Oferta", Collumns);
            foreach (var item in OfferInformation)
            {
                dataGridView1.Rows.Add(item[1], item[2], item[3]);
            }      
        }
        // Powrót do głównego panelu pacjenta
        private void Label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
