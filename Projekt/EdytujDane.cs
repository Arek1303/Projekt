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
    //Wywołanie panelu edycji danych
    public partial class AccountEdit : Form
    {
        string PatientID;
        public AccountEdit(string idPatient)
        {
            InitializeComponent();
            this.PatientID = idPatient;
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }
        //Wywołanie powrotu do panelu głównego
        private void Label6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wywołąnie powrotu do panelu głównego poprzez użycie przycisku panelu górnego
        private void EdytujDane_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wywołanie operacji edycji danych pacjent
        private void Button1_Click(object sender, EventArgs e)
        {
            WczytywanieZBazy Load = new WczytywanieZBazy();
            string Condition = "id='" + PatientID + "'";
            List<string> Data = new List<string> { Condition, "Imie='" + name.Text + "'", "Nazwisko='" + surname.Text + "'", "Wiek='" + age.Text + "'", "Login='" + login.Text + "'", "Haslo='" + password.Text + "'" };
            Load.SendUpdate(Data, "Pacjent ");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

    }
}
