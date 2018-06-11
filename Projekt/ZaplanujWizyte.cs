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
    public partial class PlanVisit : Form
    {
        string NumberID;
        public PlanVisit(string numberIdPatient)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            TimePicker.ShowUpDown = true;
            NumberID = numberIdPatient;
        }
        // Powrót do głównego panelu
        private void Label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wysłanie propozycji do lekarza
        private void Button1_Click(object sender, EventArgs e)
        {
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Date = new List<string> { "1", NumberID, DataPicker.Value.ToString("yyyy-MM-dd"), "0", TimePicker.Text };
            Load.SendData(Date, "Wizyta (IdLekarz,IdPacjent,DataWizyty,Status,Godzina)");
            this.Dispose();
        }
    }
}
