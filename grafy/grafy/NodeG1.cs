using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    internal class NodeG1
    {
        public int data;

        public NodeG1(int data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
