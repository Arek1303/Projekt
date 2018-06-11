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
    public partial class NewsCrud : Form
    {
        //Wywołanie panelu zarządzania aktualizacjami
        public NewsCrud()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(684, 382);
            this.MaximumSize = new Size(684, 382);
            this.MaximizeBox = false;
            LoadData();
        }
        // Połączenie z bazą i wczytanie aktualności
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<List<string>> PatientInformation;
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Patient = new List<string>();
            List<string> Columns = new List<string>
            {
                "ID", "Tytul", "Opis", "Data"
            };
            PatientInformation = Load.LoadData("Aktualnosc", Columns);
            foreach (var item in PatientInformation)
            {
                dataGridView1.Rows.Add(item[0], item[1], item[2], item[3].Substring(0, 10));
            }
        }
        // Metoda usuwania aktualności
        private void BtnUsun_Click(object sender, EventArgs e)
        {
            string ChoosenId = dataGridView1.SelectedCells[0].Value.ToString();
            WczytywanieZBazy Load = new WczytywanieZBazy();
            Load.DeleteData("id = '" + ChoosenId + "'", "Aktualnosc");
            LoadData();
        }
        // Metoda dodawania aktualności
        private void BtnDodaj_Click(object sender, EventArgs e)
        { 
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<string> Data = new List<string> { txtTytul.Text,txtOpis.Text, DateTime.Now.ToString("yyyy-MM-dd")};
            Load.SendData(Data, "Aktualnosc (Tytul,Opis,Data)");
            LoadData();
        }
        // Metoda powrotu do panelu głównego
        private void CrudAktualizacja_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }

}
