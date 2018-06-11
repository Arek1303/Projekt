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
    //Wywołanie panelu zarządzania wizytami
    public partial class VisitCrud : Form
    {
        public VisitCrud()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            LoadData();
        }
        //Wczytanie wizyt i wyświetlenie ich wraz z odpowiednimi statusami
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> VisitInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Columns = new List<string>
            {
                "ID", "IdPacjent", "DataWizyty", "Godzina", "Status"
            };
            VisitInformation = Load.LoadData("Wizyta", Columns);

            foreach (var item in VisitInformation)
            {
                var state = item[4];
                if (state == "0")
                {
                    state = "Nieprzetworzone";
                }
                else if (state == "1")
                {
                    state = "Zatwierdzony";
                }
                else if (state == "2")
                {
                    state = "Odrzucony";
                }
                else if (state == "3")
                {
                    state = "Odbyte";
                }
                var Name = LoadName(item[1]);
                dataGridView1.Rows.Add(item[0], Name, item[2].Substring(0, 10), item[3].Remove(0, 11), state);
            }
        }
        // Metoda zmieniająca status wizyty
        private void BtnZmien_Click(object sender, EventArgs e)
        {
            string Choose = ChooseState();
            string ChoosenId = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            string Condition= "id='" + ChoosenId + "'";
            List<string> Data = new List<string> { Condition, "Status='" + Choose + "'" };
            wczytaj.SendUpdate(Data, "Wizyta ");
            LoadData();
        }
        // Modyfikacja w celu czytelności informacji
        private string ChooseState()
        {
            if ((string)comboBox1.SelectedItem == "Zatwierdzony")
            {
                return "1";
            }
            else if ((string)comboBox1.SelectedItem == "Odrzucony")
            {
                return "2";
            }
            else if ((string)comboBox1.SelectedItem == "Odbyte")
            {
                return "3";
            }
            else
            {
                return "0";
            }
        }
        public string LoadName(string id)
        {
            List<List<string>> VisitInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Columns = new List<string>
            {
                "Imie", "Nazwisko"
            };
            VisitInformation = Load.LoadData("Pacjent", Columns, "id='" + id + "'");
            if (VisitInformation.Count != 0)
            {
                return VisitInformation[0][0] + " " + VisitInformation[0][1];
            }
            else
            {
                return "Taki pacjent już nie istnieje";
            }

        }
        // Powrót do menu głównego
        private void CrudWizyty_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
