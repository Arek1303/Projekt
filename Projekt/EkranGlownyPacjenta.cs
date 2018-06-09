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
    public partial class EkranGlownyPacjenta : Form
    {
        //Wywołanie głównego panelu pacjenta
        List<string> informacjeOPacjencie;
        public EkranGlownyPacjenta(List<string> info)
        {
            InitializeComponent();
            informacjeOPacjencie = info;
            powitanie.Text = "Witaj " + informacjeOPacjencie[1] + " " + informacjeOPacjencie[2];
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }
        //Wywołanie powrotu to głównego panelu pacjenta
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new AktualnosciPacjent())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołanie przejścia do statusów wizyt pacjenta
        private void button3_Click(object sender, EventArgs e)
        {
            using (var form = new ZatwierdzoneWizyty(informacjeOPacjencie[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołanie przejścia do panelu logowania
        private void button7_Click(object sender, EventArgs e)
        {
            Logowanie logow = new Logowanie();
            this.Dispose();
            logow.Show(); 
        }
        //Wywołanie przejścia do panelu wizyt pacjenta
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new ZaplanujWizyte(informacjeOPacjencie[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołaniedze przejścia do panelu edycji danych pacjenta
        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            using (var form = new EdytujDane(informacjeOPacjencie[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }

            }
        }
        //Wywołaniedze przejścia do panelu obserwacji aktualności przychodni
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new Oferta())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
    }
}
