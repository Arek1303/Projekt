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
    public partial class OfferCrud : Form
    {
        //Wywołanie panelu zarządzania oferatmi
        public OfferCrud()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            LoadData();
        }
        // Połączenie z bazą i wczytanie ofert
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> PatientInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Columns = new List<string>
            {
                "ID", "Nazwa", "Opis", "Cena"
            };
            PatientInformation = Load.LoadData("Oferta", Columns);
            foreach (var item in PatientInformation)
            {
                dataGridView1.Rows.Add(item[0], item[1], item[2], item[3]);
            }
        }
        // Metoda usuwania ofert
        private void BtnUsun_Click(object sender, EventArgs e)
        {
            string ChoosenId = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy Load = new WczytywanieZBazy();
            Load.DeleteData("id = '" + ChoosenId + "'", "Oferta");
            LoadData();
        }
       


        private List<string> DodajListeZmian()
        {
            List<string> listaDoZwrotu = new List<string>();
            if (txtNazwa.Text != "")
            {
                listaDoZwrotu.Add("Nazwa='" + txtNazwa.Text + "'");
            }
            if(txtOpis.Text != "")
            {
                listaDoZwrotu.Add("Opis='" + txtOpis.Text + "'");
            }
            if (txtCena.Text != "")
            {
                listaDoZwrotu.Add("Cena='" + txtCena.Text + "'");
            }
                       
            return listaDoZwrotu;
        }
        // Metoda dodawania oferty
        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> dane = new List<string> { txtNazwa.Text, txtOpis.Text, txtCena.Text };
            wczytaj.SendData(dane, "Oferta (Nazwa,Opis,Cena)");
            LoadData();
        }
        //Metoda edycji oferty
        private void BtnEdytuj_Click(object sender, EventArgs e)
        {
            string idZmienianego = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            string warunek = "id='" + idZmienianego + "'";
            List<string> dane = new List<string> { warunek };
            List<string> zmiany = DodajListeZmian();
            foreach (var item in zmiany)
            {
                dane.Add(item);
            }
            wczytaj.SendUpdate(dane, "Oferta ");
            LoadData();
        }
        //Metoda powrotu do głównego panelu
        private void CrudOferta_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
