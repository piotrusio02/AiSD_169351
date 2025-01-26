using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Grafy
{
    internal class Graf1
    {
        public List<NodeG1> nodes = new List<NodeG1>();
        public List<Edge> edges = new List<Edge>();

        public Graf1(Edge k)
        {
            if (k != null)
            {
                this.edges.Add(k);
                this.nodes.Add(k.start);
                this.nodes.Add(k.end);
            }
        }
        void Add(Edge k)
        {
            this.edges.Add(k);
            if (!this.nodes.Contains(k.start))
            {
                this.nodes.Add(k.start);
            }
            if (!this.nodes.Contains(k.end))
            {
                this.nodes.Add(k.end);
            }
        }

        public int IleNowychWezlow(Edge k)
        {
            int wynik = 0;
            if (!this.nodes.Contains(k.start))
            {
                wynik++;
            }
            if (!this.nodes.Contains(k.end))
            {
                wynik++;
            }
            return wynik;
        }

        public void Join(Graf1 g1)
        {
            //this | g1

            for (int i = 0; i < g1.edges.Count; i++)
            {
                this.Add(g1.edges[i]);
            }

        }


        public Graf1 AlgorytmKruskala()
        {
            //tworzenie drzewa rozpinającego
            List<Graf1> temp = new List<Graf1>();

            var krawedzie = this.edges.OrderBy(k => k.weight).ToList();


            temp.Add(new Graf1(krawedzie[0]));

            for (int i = 1; i < krawedzie.Count; i++)
            {
                var k = krawedzie[i];
                int l = -1;
                for (int j = 0; j < temp.Count; j++)
                {
                    var g = temp[j];
                    switch (g.IleNowychWezlow(k))
                    {
                        case 0:
                            j = temp.Count;
                            break;

                        case 1:
                            if (l < 0)
                            {
                                g.Add(k);
                                l = j;
                            }
                            else
                            {
                                temp[l].Join(g);
                                temp.RemoveAt(j);
                                j = temp.Count;
                                break;
                            }

                            break;

                        case 2:
                            temp.Add(new Graf1(k));
                            break;
                    }
                }


            }

            return temp[0];
        }

        public List<Element> PrzygotujTabelke(NodeG1 start)
        {
            var wynik = new List<Element>();
            var NodeMJ = new NodeG1(-1);
            wynik.Add(new Element(start, 0, NodeMJ));
            for (int i = 1; i < this.nodes.Count; i++)
            {
                wynik.Add(new Element(this.nodes[i], int.MaxValue, NodeMJ));
            }
            return wynik;
        }

        public List<Edge> znajdzSasiedzi(NodeG1 wezel)
        {
            var wynik = new List<Edge>();
            for (int i = 0; i < this.edges.Count; i++)
            {
                if (this.edges[i].start == wezel)
                {
                    wynik.Add(this.edges[i]);
                }
            }
            return wynik;
        }

        public List<Element> AlgorytmDijkstry(NodeG1 start)
        {
            var tabelka = this.PrzygotujTabelke(start);
            var zbiorS = new List<NodeG1>();
            for (int i = 0; i < tabelka.Count - 1; i++)
            {
                var kandydaci = tabelka.Where(e => !zbiorS.Contains(e.wezel)).ToList();
                var badany = kandydaci.OrderBy(e => e.dystans).First();
                zbiorS.Add(badany.wezel);

                var sasiedzi = znajdzSasiedzi(badany.wezel);

                for (int j = 0; j < sasiedzi.Count; j++)
                {
                    foreach (var e in kandydaci)
                    {
                        if (sasiedzi[j].end == e.wezel && badany.dystans + sasiedzi[j].weight < e.dystans)
                        {
                            e.dystans = badany.dystans + sasiedzi[j].weight;
                            e.poprzednik = badany.wezel;
                        }
                    }
                }

            }

            return tabelka;
        }
    }
}
