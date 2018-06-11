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

    // Wywołanie panelu zarządzania pacjentami
    public partial class PatientCrud : Form
    {
        public PatientCrud()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
            LoadData();

        }
        // Wczytanie listy pacjentów
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> PatientInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Columns = new List<string>
            {
                "ID", "Imie", "Nazwisko", "Wiek"
            };
            PatientInformation = Load.LoadData("Pacjent", Columns);
            foreach (var item in PatientInformation)
            {
                dataGridView1.Rows.Add(item[0], item[1], item[2], item[3]);
            }
        }
        // Usuwanie wybranego pacjenta
        private void Button1_Click(object sender, EventArgs e)
        {
            string ChoosenId = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy Load = new WczytywanieZBazy();
            Load.DeleteData("id = '" + ChoosenId + "'", "Pacjent");
            LoadData();
        }
        // Powrót do menu głownego
        private void CrudPacjent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
