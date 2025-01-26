using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    internal class Element
    {
        public NodeG1 wezel;
        public int dystans;
        public NodeG1 poprzednik;

        public Element(NodeG1 wezel, int dystans, NodeG1 poprzednik)
        {
            this.wezel = wezel;
            this.dystans = dystans;
            this.poprzednik = poprzednik;
        }
    }
}
