using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drzewa
{
    public partial class Form1 : Form
    {
        BST drzewo = new BST();
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
        }
        int[] Parsowanie(string text)
        {
            string[] temp = text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i].Trim();
            }

            int[] t = new int[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                t[i] = int.Parse(temp[i]);
            }


            return t;
        }


        private void AddNodes(TreeNode treeNode, NodeT tempNodeT)
        {
            if (tempNodeT.lewe != null)
            {
                TreeNode leftNode = new TreeNode(tempNodeT.lewe.data.ToString());
                treeNode.Nodes.Add(leftNode);
                AddNodes(leftNode, tempNodeT.lewe);
            }

            if (tempNodeT.prawe != null)
            {
                TreeNode rightNode = new TreeNode(tempNodeT.prawe.data.ToString());
                treeNode.Nodes.Add(rightNode);
                AddNodes(rightNode, tempNodeT.prawe);
            }
        }


        public void WyswietlDrzewo()
        {
            treeView1.Nodes.Clear();

            if (drzewo.root != null)
            {
                TreeNode rootNode = new TreeNode(drzewo.root.data.ToString());
                treeView1.Nodes.Add(rootNode);
                AddNodes(rootNode, drzewo.root);
                treeView1.ExpandAll();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {   
                drzewo = new BST();
                int[] tablica = Parsowanie(textBox1.Text);


                for (int i = 0; i < tablica.Length; i++)
                {
                    drzewo.dodaj(tablica[i]);
                }

                WyswietlDrzewo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int liczba = int.Parse(textBox2.Text);

            drzewo.usun(liczba);

            WyswietlDrzewo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String napis = null;
            drzewo.porzadek(drzewo.root, 1, ref napis);
            label2.Text = napis;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String napis = null;
            drzewo.porzadek(drzewo.root, 2, ref napis);
            label2.Text = napis;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String napis = null;
            drzewo.porzadek(drzewo.root, 3, ref napis);
            label2.Text = napis;
        }
    }
}
