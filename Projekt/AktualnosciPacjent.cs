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
    public partial class PatientNews : Form
    {
        // Wywołanie okna przeglądania aktualności
        public PatientNews()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 582);
            this.MaximumSize = new Size(668, 582);
            this.MaximizeBox = false;

            List<List<string>> ListOfNews;
            WczytywanieZBazy Loader = new WczytywanieZBazy();
            List<string> columns = new List<string>
            {
                "ID", "Tytul", "Opis", "Data"
            };
            ListOfNews = Loader.LoadData("Aktualnosc", columns);
            // Generowanie podglądu aktualności w zależności od ich lczby
            if (ListOfNews.Count() > 0)
            {
                FirstTitle.Text = ListOfNews[0][1];
                FirstDescription.Text = ListOfNews[0][2];
                FirstDate.Text = ListOfNews[0][3];
            }
            else
            {
                HideFirst();
            }
            if (ListOfNews.Count() > 1)
            {
                SecondTitle.Text = ListOfNews[1][1];
                SecondDescription.Text = ListOfNews[1][2];
                SecondDate.Text = ListOfNews[1][3];
            }
            else
            {
                HideSecond();
            }
            if (ListOfNews.Count() > 2)
            {
                ThirdTitle.Text = ListOfNews[2][1];
                ThirdDescription.Text = ListOfNews[2][2];
                ThirdDate.Text = ListOfNews[2][3];
            }
            else
            {
                HideThird();
            }
        }
        // Wywołanie powrotu do głównego panelu pacjenta
        private void Label5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        // Wywołanie ukrywania poszczególnych paneli
        public void HideFirst()
        {
            FirstTitle.Hide();
            FirstDescription.Hide();
            FirstDate.Hide();
        }
        public void HideSecond()
        {
            SecondDate.Hide();
            SecondDescription.Hide();
            SecondTitle.Hide();

        }
        public void HideThird()
        {
            ThirdDate.Hide();
            ThirdDescription.Hide();
            ThirdTitle.Hide();
        }
    }
}
