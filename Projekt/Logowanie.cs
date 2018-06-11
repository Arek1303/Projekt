using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{

    public partial class Login : Form
    {
        private CheckLogin tester = new CheckLogin();
        // Wywołanie panelu logowania
        public Login()
        {
            InitializeComponent();
            //Ukrycie hasła logowania
            txtPassword.UseSystemPasswordChar = true;
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }
        // Wywołanie powrotu to początkowego panelu
        private void Label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
            
        }
        //Wywołanie logowania do systemu
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != string.Empty && txtPassword.Text != string.Empty)
            {
                // Sprawdzenie logowania jako pacjent
                var numerID = tester.CheckPatient(txtLogin.Text, txtPassword.Text);
                if (numerID != 0)
                {
                    this.Hide();
                    WczytywanieZBazy Load = new WczytywanieZBazy();
                    List<string> Patient = new List<string>();
                    List<string> Columns = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Wiek","Login", "Haslo"
                    };
                    string Condition = "ID='" + numerID + "'";
                    Patient = Load.LoadData("Pacjent", Columns, Condition)[0];

                    MainPatientForm PatientForm = new MainPatientForm(Patient);
                    PatientForm.Show();
                }
                else
                {
                    //Sprawdzenie logowania jako lekarz
                    numerID = tester.ChecKDoctor(txtLogin.Text, txtPassword.Text);
                    if (numerID != 0)
                    {
                        this.Hide();
                        WczytywanieZBazy Load = new WczytywanieZBazy();
                        List<string> Doctor = new List<string>();
                        List<string> Columns = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Specjalizacja","Login", "Haslo"
                    };
                        string Condition = "ID='" + numerID + "'";
                        Doctor = Load.LoadData("Lekarz", Columns, Condition)[0];

                        MainDoctorForm DoctorForm = new MainDoctorForm(Doctor);
                        DoctorForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Błędny Login lub Hasło!", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                
                
            }
        }
    }
}
