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
    public partial class EkranGlownyLekarza : Form
    {
        public EkranGlownyLekarza(List <string> lekarz)
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }

        // Generowanie pliku pdf
        private void button2_Click(object sender, EventArgs e)
        {
            //Wczytanie danych
            WczytywanieZBazy wczytaj = new WczytywanieZBazy();
            List<List<string>> pacjenci = new List<List<string>>();
            List<string> tabele = new List<string>
                    {
                       "ID", "Imie", "Nazwisko", "Wiek","Login", "Haslo"
                    };
            pacjenci = wczytaj.WczytajRekordy("Pacjent", tabele);
            // Utworzenie pliku, ukreślenie rodzaju i rozmiaru dokumentu
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();
            // Określenie rodzaju wydruku
            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("Lista Pacjentow"));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            // Wstawienie danych do tabeli
            foreach (var item in pacjenci)
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
        private void btnPacjenci_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new CrudPacjent())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new CrudAktualizacja())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new CrudWizyty())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do kolejnego panelU
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new CrudOferta())
            {
                var formResult = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }
        // Przejście do panelu logowania
        private void button3_Click(object sender, EventArgs e)
        {
            Logowanie logow = new Logowanie();
            this.Dispose();
            logow.Show();
        }
    }
}
