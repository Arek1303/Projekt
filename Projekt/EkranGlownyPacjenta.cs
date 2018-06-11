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
    public partial class MainPatientForm : Form
    {
        //Wywołanie głównego panelu pacjenta
        List<string> PatientInformation;
        public MainPatientForm(List<string> info)
        {
            InitializeComponent();
            PatientInformation = info;
            powitanie.Text = "Witaj " + PatientInformation[1] + " " + PatientInformation[2];
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }
        //Wywołanie powrotu to głównego panelu pacjenta
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new PatientNews())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołanie przejścia do statusów wizyt pacjenta
        private void Button3_Click(object sender, EventArgs e)
        {
            using (var form = new ApproveVisit(PatientInformation[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołanie przejścia do panelu logowania
        private void Button7_Click(object sender, EventArgs e)
        {
            Login logow = new Login();
            this.Dispose();
            logow.Show(); 
        }
        //Wywołanie przejścia do panelu wizyt pacjenta
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new PlanVisit(PatientInformation[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołaniedze przejścia do panelu edycji danych pacjenta
        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new AccountEdit(PatientInformation[0]))
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        //Wywołaniedze przejścia do panelu obserwacji aktualności przychodni
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new Offer())
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
