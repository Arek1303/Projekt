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
    // Panel obsługujący wyświetlenie informacji pacjentowi wraz z ich statusem
    public partial class ApproveVisit : Form
    {
        // Połączenie z bazą danych i wczytanie wizyt danego pacjenta
        public ApproveVisit(string idPatient)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;

            List<List<string>> VisitInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Visit = new List<string>();
            string Condition = "IdPacjent='" + idPatient + "'";
            List<string> Columns = new List<string>
            {
                "ID", "DataWizyty", "Godzina","Status"
            };
            // Edycja wczytanych danych w celu przygotowania widoku dla pacjenta
            VisitInformation = Load.LoadData("Wizyta", Columns,Condition);
            foreach (var item in VisitInformation)
            {
                var State = item[3];
                if (State == "0")
                {
                    State = "Nieprzetworzone";
                }
                else if (State == "1")
                {
                    State = "Zatwierdzony";
                }
                else if(State == "2")
                {
                    State = "Odrzucony";
                }
                else if(State == "3")
                {
                    State = "Odbyte";
                }

                dataGridView1.Rows.Add(item[1].Substring(0,10), item[2].Remove(0,11), State);
            }
        }
        //Powrót do panelu głównego
        private void Label3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }


    }
}
