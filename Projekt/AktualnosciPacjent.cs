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
    public partial class AktualnosciPacjent : Form
    {
        // Wywołanie okna przeglądania aktualności
        public AktualnosciPacjent()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 582);
            this.MaximumSize = new Size(668, 582);
            this.MaximizeBox = false;

            List<List<string>> informacjeOAktualnosci;
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> aktualnosc = new List<string>();
            List<string> tabele = new List<string>
            {
                "ID", "Tytul", "Opis", "Data"
            };
            informacjeOAktualnosci = wczytaj.WczytajRekordy("Aktualnosc", tabele);
            // Generowanie podglądu aktualności w zależności od ich lczby
            if (informacjeOAktualnosci.Count() > 0)
            {
                AktualnoscPierwszaTytul.Text = informacjeOAktualnosci[0][1];
                AktualnoscPierwszaOpis.Text = informacjeOAktualnosci[0][2];
                AktualnoscPierwszaData.Text = informacjeOAktualnosci[0][3];
            }
            else
            {
                UkryjPierwsze();
            }
            if (informacjeOAktualnosci.Count() > 1)
            {
                AktualnoscDrugaTytul.Text = informacjeOAktualnosci[1][1];
                AktualnoscDrugaOpis.Text = informacjeOAktualnosci[1][2];
                AktualnoscDrugaData.Text = informacjeOAktualnosci[1][3];
            }
            else
            {
                UkryjDrugie();
            }
            if (informacjeOAktualnosci.Count() > 2)
            {
                AktualnoscTrzeciaTytul.Text = informacjeOAktualnosci[2][1];
                AktualnoscTrzeciaOpis.Text = informacjeOAktualnosci[2][2];
                AktualnoscTrzeciaData.Text = informacjeOAktualnosci[2][3];
            }
            else
            {
                UkryjTrzecie();
            }
        }
        // Wywołanie powrotu do głównego panelu pacjenta
        private void label5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wywołanie ukrywania poszczególnych paneli
        public void UkryjPierwsze()
        {
            AktualnoscPierwszaTytul.Hide();
            AktualnoscPierwszaOpis.Hide();
            AktualnoscPierwszaData.Hide();
        }
        public void UkryjDrugie()
        {
            AktualnoscDrugaData.Hide();
            AktualnoscDrugaOpis.Hide();
            AktualnoscDrugaTytul.Hide();

        }
        public void UkryjTrzecie()
        {
            AktualnoscTrzeciaData.Hide();
            AktualnoscTrzeciaOpis.Hide();
            AktualnoscTrzeciaTytul.Hide();
        }
    }
}
