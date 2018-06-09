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
    // Formularz obsługujący planowanie wizyt przez pacjenta 
    public partial class ZaplanujWizyte : Form
    {
        string numerID;
        public ZaplanujWizyte(string numerIdPacjenta)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            CzasPicker.ShowUpDown = true;
            numerID = numerIdPacjenta;
        }
        // Powrót do głównego panelu
        private void label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wysłanie propozycji do lekarza
        private void button1_Click(object sender, EventArgs e)
        {
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<string> dane = new List<string> { "1", numerID, DataPicker.Value.ToString("yyyy-MM-dd"), "0", CzasPicker.Text };
            wczytaj.WyslijNoweDane(dane, "Wizyta (IdLekarz,IdPacjent,DataWizyty,Status,Godzina)");
            this.Dispose();
        }
    }
}
