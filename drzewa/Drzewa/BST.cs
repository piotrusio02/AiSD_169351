using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
    internal class BST
    {
        public NodeT root;
        public void dodaj(int liczba)
        {
            NodeT NowyNodeT = new NodeT(liczba);
            if (this.root == null)
            {
                this.root = NowyNodeT;
            }
            else
            {
                NodeT temp = root;
                NodeT parent = null;

                while (temp != null)
                {
                    parent = temp;

                    if (liczba < temp.data)
                    {
                        temp = temp.lewe;
                    }
                    else
                    {
                        temp = temp.prawe;
                    }
                }

                NowyNodeT.rodzic = parent;

                if (liczba < parent.data)
                {
                    parent.lewe = NowyNodeT;
                }
                else
                {
                    parent.prawe = NowyNodeT;
                }


            }
        }
        public void znajdzRodzica(NodeT wezel, int liczba, ref NodeT usun)
        {
            if (wezel == null)
                return;
            if (wezel.data == liczba)
                usun = wezel;
            znajdzRodzica(wezel.lewe, liczba, ref usun);
            znajdzRodzica(wezel.prawe, liczba, ref usun);

        }

        public void zeroDzieci(NodeT usun)
        {
            if (usun.rodzic.data > usun.data)
            {
                usun.rodzic.lewe = null;
                usun.rodzic = null;
                return;
            }
            else
            {
                usun.rodzic.prawe = null;
                usun.rodzic = null;
                return;
            }
        }


        public void jednoDziecko(NodeT usun)
        {
            if (usun.lewe == null)
            {
                if (usun.rodzic.data > usun.data)
                {
                    usun.prawe.rodzic = usun.rodzic;
                    usun.rodzic.lewe = usun.prawe;
                    usun.rodzic = null;
                    usun.prawe = null;
                    return;
                }
                else
                {
                    usun.rodzic.prawe = usun.prawe;
                    usun.prawe.rodzic = usun.rodzic;
                    usun.rodzic = null;
                    usun.prawe = null;
                    return;
                }
            }
            if (usun.prawe == null)
            {
                if (usun.rodzic.data > usun.data)
                {
                    usun.lewe.rodzic = usun.rodzic;
                    usun.rodzic.lewe = usun.lewe;
                    usun.rodzic = null;
                    usun.lewe = null;
                    return;
                }
                else
                {
                    usun.rodzic.prawe = usun.lewe;
                    usun.lewe.rodzic = usun.rodzic;
                    usun.rodzic = null;
                    usun.lewe = null;
                    return;
                }
            }

        }

        public void dwaDzieci(NodeT usun)
        {
            NodeT praweD = usun.prawe;

            while (praweD.lewe != null)
            {
                praweD = praweD.lewe;
            }

            if (praweD.lewe == null && praweD.prawe == null)
            {
                usun.data = praweD.data;
                zeroDzieci(praweD);
                return;
            }

            if (praweD.lewe == null || praweD.prawe == null)
            {
                usun.data = praweD.data;
                jednoDziecko(praweD);
                return;
            }
        }
        public void usun(int liczba)
        {

            NodeT usun = null;
            znajdzRodzica(root, liczba, ref usun);


            if (usun.lewe == null && usun.prawe == null)
            {
                zeroDzieci(usun);
                return;
            }

            if (usun.lewe == null || usun.prawe == null)
            {
                jednoDziecko(usun);
                return;
            }

            dwaDzieci(usun);
            return;

        }
        public void porzadek(NodeT wezel, int liczba, ref String napis)
        {
            if (wezel == null)
                return;
            if (liczba == 1)
                napis += wezel.data.ToString() + " ";

            porzadek(wezel.lewe, liczba, ref napis);

            if (liczba == 2)
                napis += wezel.data.ToString() + " ";

            porzadek(wezel.prawe, liczba, ref napis);

            if (liczba == 3)
                napis += wezel.data.ToString() + " ";


        }
    }
}
