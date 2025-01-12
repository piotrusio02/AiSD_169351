using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace listy
{
    public partial class Form1 : Form
    {
        List lista = new List();
        public Form1()
        {
            InitializeComponent();
 
            label1.Text = "Lista: brak elementów";
            label2.Text = "Liczba elementów w liście: ";
            label3.Text = "Na podanym indexie znajduje się liczba: ";

            for (int i = 100; i >= 0; i--)
            {
                domainUpDown1.Items.Add(i.ToString());
            }
            domainUpDown1.SelectedIndex = 100;
        }

        public void Wypisz() // wypisywanie liczby elementów w liście
        {
            if(lista.count < 0)
            {
                lista.count = 0;
            }
            label2.Text = "Liczba elementów w liście: " + lista.count.ToString();
        }

        public void Wyswietl() // wyświetlanie zaktualizowanej listy
        {
            if (lista.head == null)
            {
                label1.Text = "Lista: brak elementów";
                return;
            }
            else
            {
                label1.Text = "Lista: ";
            }

            Node temp = lista.head;
            while(temp != null)
            {
                label1.Text += temp.data.ToString() + ", ";
                temp = temp.next;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Dodaj element na początek listy
        {
            lista.AddFirst(int.Parse(domainUpDown1.Text));
            Wyswietl();
            Wypisz();
        }

        private void button2_Click(object sender, EventArgs e) // Usuń pierwszy element z listy
        {
            lista.RemoveFirst();
            Wyswietl();
            Wypisz();

        }

        private void button4_Click(object sender, EventArgs e) // Dodaj element na koniec listy
        {
            lista.AddLast(int.Parse(domainUpDown1.Text));
            Wyswietl();
            Wypisz();
        }

        private void button3_Click(object sender, EventArgs e) // Usuń ostatni element z listy
        {
            lista.RemoveLast();
            Wyswietl();
            Wypisz();
        }

        private void button5_Click(object sender, EventArgs e) // znajdź element z listy po jego indexie
        {

            if (int.TryParse(textBox1.Text, out int temp) && (temp < lista.count))
            {
                label3.Text = "Na podanym indexie znajduje się liczba: " + lista.Znajdz(temp).ToString();
            }
            else
            {
                label3.Text = "Na podanym indexie znajduje się liczba: Zły index";
            }

        
        }
    }
}
