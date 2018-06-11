using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    // Wyświetlnie panelu głównego lekarza
    public partial class MainDoctorForm : Form
    {
        public MainDoctorForm(List <string> lekarz)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }

        // Generowanie pliku pdf
        private void Button2_Click(object sender, EventArgs e)
        {
            //Wczytanie danych
            WczytywanieZBazy Load = new WczytywanieZBazy();
            List<List<string>> Patients = new List<List<string>>();
            List<string> Columns = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Wiek","Login", "Haslo"
                    };
            Patients = Load.LoadData("Pacjent", Columns);
            // Utworzenie pliku, ukreślenie rodzaju i rozmiaru dokumentu
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();
            // Określenie rodzaju wydruku
            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("Lista Pacjentow"))
            {
                Colspan = 4,
                HorizontalAlignment = 1
            };
            table.AddCell(cell);
            // Wstawienie danych do tabeli
            foreach (var item in Patients)
            {
                table.AddCell(item[0]);
                table.AddCell(item[1]);
                table.AddCell(item[2]);
                table.AddCell(item[3]);
            }
            doc.Add(table);
            doc.Close();

            System.Diagnostics.Process.Start(@"Test.pdf");
        }
        // Przejście do kolejnego panelU
        private void BtnPacjenci_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new PatientCrud())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new NewsCrud())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new VisitCrud())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new OfferCrud())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do panelu logowania
        private void Button3_Click(object sender, EventArgs e)
        {
            Login logow = new Login();
            this.Dispose();
            logow.Show();
        }
    }
}
