using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grafy
{
    internal class Graf
    {
        public List<NodeG> nodes = new List<NodeG>();

        public bool czyWLiscie(NodeG element, List<NodeG> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (element == lista[i])
                {
                    return true;
                }
            }
            return false;
        }
        public List<NodeG> Wszerz(NodeG start)
        {
            List<NodeG> lista = new List<NodeG>() { start };

            for (int i = 0; i < lista.Count; i++)
            {
                NodeG temp = lista[i];

                for (int j = 0; j < temp.sasiedzi.Count; j++)
                {
                    if (!czyWLiscie(temp.sasiedzi[j], lista))
                    {
                        lista.Add(temp.sasiedzi[j]);
                    }
                }
            }

            return lista;
        }

    }
}
