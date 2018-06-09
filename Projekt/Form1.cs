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
    public partial class Form1 : Form
    {
        // Główne okno aplikacji
        public Form1()
        {
            InitializeComponent();
            //Ustawienie stałych rozmiarów okna
            this.MinimumSize = new Size(668, 382);
            this.MaximumSize = new Size(668, 382);
            this.MaximizeBox = false;
        }

        //Wywołanie przekierowania do panelu logowania
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie login = new Logowanie();
            login.Show();
        }
        //Wywołanie przekierowania do panelu rejestracji

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rejestracja rejestr = new Rejestracja();
            rejestr.Show();
        }
        //Wywołanie zamknięcia aplikacji
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

    }
}
