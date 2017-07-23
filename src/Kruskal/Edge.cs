using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kruskal
{
    public class Edge
    {
        public int source;
        public int destination;
        public int weight;

        public int ComparetTo(Edge compareTo)
        {
            return this.weight - compareTo.weight;
        }

    }
}
