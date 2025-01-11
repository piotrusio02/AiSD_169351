using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortowanie
{
    public partial class Form1 : Form
    {
        int[] tab;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Przed: ";
            label2.Text = "Po: ";
            label3.Text = "Czas sortowania: ";
            domainUpDown1.Text = "10";
        }

        private void button6_Click(object sender, EventArgs e) // generowanie tablicy
        {
            int rozmiar = int.Parse(domainUpDown1.Text);
            tab = Generuj(rozmiar);
            label1.Text = "Przed: " + string.Join(",", tab);
            label2.Text = "Po: ";
            label3.Text = "Czas sortowania: ";
        }

        public static int[] Generuj(int rozmiar)
        {
            Random random = new Random();
            int[] tab = new int[rozmiar];
            for(int i = 0;i< rozmiar; i++)
            {
                tab[i] = random.Next(1, 101);
            }
            return tab;
        }

        private void button1_Click(object sender, EventArgs e) // sortowanie bąbelkowe
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int temp;
            for(int i = 0; i< tab.Length; i++)
            {
                for(int j = 0; j < tab.Length - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
            watch.Stop();
            label2.Text = "Po: " + string.Join(", ", tab);
            label3.Text = "Czas sortowania: " + watch.Elapsed.TotalMilliseconds.ToString("F3") + " ms";

        }

        private void button2_Click(object sender, EventArgs e) // sortowanie przez wstawianie
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for(int i = 1; i < tab.Length; i++)
            {
                int temp = tab[i];
                int j = i - 1;

                while(j >= 0 && tab[j] > temp)
                {
                    tab[j + 1] = tab[j];
                    j--;
                }
                tab[j + 1] = temp;
            }
            watch.Stop();
            label2.Text = "Po: " + string.Join(", ", tab);
            label3.Text = "Czas sortowania: " + watch.Elapsed.TotalMilliseconds.ToString("F3") + " ms";
        }

        private void button3_Click(object sender, EventArgs e) // sortowanie przez scalanie
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            MergeSort(tab);

            watch.Stop();
            label2.Text = "Po: " + string.Join(", ", tab);
            label3.Text = "Czas sortowania: " + watch.Elapsed.TotalMilliseconds.ToString("F3") + " ms";

        }

        public static void MergeSort(int[] tab)
        {
            if(tab.Length <= 1)
            {
                return;
            }
            int mid = tab.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[tab.Length - mid];

            for(int i = 0; i < mid; i++)
            {
                left[i] = tab[i];
            }
            for(int i = mid;i< tab.Length; i++)
            {
                right[i - mid] = tab[i];
            }

            MergeSort(left);
            MergeSort(right);

            Merge(tab, left, right);
        }

        public static void Merge(int[] tab, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while(i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    tab[k++] = left[i++];
                }
                else
                {
                    tab[k++] = right[j++];
                }
            }
            while( i < left.Length)
            {
                tab[k++] = left[i++];
            }
            while( j < right.Length)
            {
                tab[k++] = right[j++];
            }
        }

        private void button4_Click(object sender, EventArgs e) // sortowanie szybkie
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int left = 0;
            int right = tab.Length - 1;
            QuickSort(tab, left, right);

            watch.Stop();
            label2.Text = "Po: " + string.Join(", ", tab);
            label3.Text = "Czas sortowania: " + watch.Elapsed.TotalMilliseconds.ToString("F3") + " ms";
        }

        public static void QuickSort(int[] tab, int left, int right)
        {
            if (left < right)
            {
                int pivot = Podzial(tab, left, right);
                QuickSort(tab, left, pivot - 1);
                QuickSort(tab, pivot + 1, right);
            }
        }

        public static int Podzial(int[] tab, int left, int right)
        {
            int pivot = tab[right];
            int i = left - 1;

            for(int j = left; j < right; j++)
            {
                if (tab[j] <= pivot)
                {
                    i++;
                    int temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                }
            }
            int temp1 = tab[i + 1];
            tab[i + 1] = tab[right];
            tab[right] = temp1;
            return i + 1;
        }

        private void button5_Click(object sender, EventArgs e) // sortowanie przez zliczanie
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int max = tab.Max();
            int[] count = new int[max + 1];

            for(int i = 0; i < tab.Length; i++)
            {
                count[tab[i]]++;
            }
            int index = 0;
            for(int i = 0; i <= max; i++)
            {
                while (count[i] > 0)
                {
                    tab[index++] = i;
                    count[i]--;
                }
            }

            watch.Stop();
            label2.Text = "Po: " + string.Join(", ", tab);
            label3.Text = "Czas sortowania: " + watch.Elapsed.TotalMilliseconds.ToString("F3") + " ms";
        }
    }
}
