using Grafy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graf Graf = new Graf();
        Graf1 GrafKiD = new Graf1(null);

        private void button1_Click(object sender, EventArgs e)
        {
            NodeG A = new NodeG(1);
            NodeG B = new NodeG(2);
            NodeG C = new NodeG(7);
            NodeG D = new NodeG(3);
            NodeG E = new NodeG(4);
            NodeG F = new NodeG(6);
            NodeG G = new NodeG(5);

            A.sasiedzi = new List<NodeG>() { B, C };
            B.sasiedzi = new List<NodeG>() { A, D, E };
            C.sasiedzi = new List<NodeG>() { A, D, F };
            D.sasiedzi = new List<NodeG>() { B, C, F };
            E.sasiedzi = new List<NodeG>() { B, F };
            F.sasiedzi = new List<NodeG>() { E, D, C, G };
            G.sasiedzi = new List<NodeG>() { F };

            Graf.nodes = new List<NodeG>() { A, B, C, D, E, F, G };

            NodeG1 N0 = new NodeG1(0);
            NodeG1 N1 = new NodeG1(1);
            NodeG1 N2 = new NodeG1(2);
            NodeG1 N3 = new NodeG1(3);
            NodeG1 N4 = new NodeG1(4);
            NodeG1 N5 = new NodeG1(5);

            Edge E01 = new Edge(N0, N1, 3);
            Edge E04 = new Edge(N0, N4, 3);
            Edge E12 = new Edge(N1, N2, 1);
            Edge E45 = new Edge(N4, N5, 2);
            Edge E50 = new Edge(N5, N0, 6);
            Edge E25 = new Edge(N2, N5, 1);
            Edge E53 = new Edge(N5, N3, 1);
            Edge E23 = new Edge(N2, N3, 3);
            Edge E31 = new Edge(N3, N1, 3);

            GrafKiD.nodes = new List<NodeG1>() { N0, N1, N2, N3, N4, N5 };
            GrafKiD.edges = new List<Edge>() { E01, E04, E12, E45, E50, E25, E23, E53, E31 };
            label1.Text = "UTWORZONO GRAF!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Graf.Wszerz(Graf.nodes[0]).Count; i++)
            {
                label2.Text += Graf.Wszerz(Graf.nodes[0])[i].ToString() + " ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Element> Tabela = GrafKiD.AlgorytmDijkstry(GrafKiD.nodes[0]);

            foreach (var kolumna in Tabela)
            {
                label3.Text += kolumna.wezel.ToString() + " ";
                label4.Text += kolumna.dystans.ToString() + " ";
                label5.Text += kolumna.poprzednik.ToString() + " ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var kruskal = GrafKiD.AlgorytmKruskala();

            label6.Text += kruskal.edges.Count.ToString();
        }
    }
}
