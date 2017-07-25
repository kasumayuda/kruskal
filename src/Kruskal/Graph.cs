using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kruskal
{
    public class Graph
    {
        private int V, E;
        public Edge[] edge;

        public Graph(int v, int e)
        {
            this.V = v;
            this.E = e; 

            edge = new Edge[E];
            for (int i = 0; i < e; i++)
            {
                edge[i] = new Edge();
            }
        }

        #region Public methods
        public void Kruskal()
        {
            Edge[] result = new Edge[this.V];

            int e = 0;
            int i = 0;
            //sort by weight - ascending
            QuickSort(ref edge, 0, result.Length);

            Subset[] subsets = new Subset[V];            
            // Create V subsets with single elements
            for (int v = 0; v < V; ++v)
            {
                subsets[v] = new Subset();
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            
            while (e < V - 1)
            {
                Edge nextEdge = new Edge();
                nextEdge = edge[i++];

                int x = Find(subsets, nextEdge.source);
                int y = Find(subsets, nextEdge.destination);

                // If including this edge does't cause cycle, include it
                // in result and increment the index of result for next edge
                if (x != y)
                {
                    result[e++] = nextEdge;
                    Union(subsets, x, y);
                }         
            }

            int cost = 0;
            for (int j = 0; j < e; j++)
            {
                Console.WriteLine(ConvertNumToLetter(result[j].source) + " -- " + ConvertNumToLetter(result[j].destination) + " == " + result[j].weight);
                cost += result[j].weight;
            }
            Console.WriteLine(string.Format("Cost : {0}", cost));
            
        } 
        #endregion

        #region Private methods
        private string ConvertNumToLetter(int i)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return letters[i].ToString();
        }

        private void QuickSort(ref Edge[] edge, int p, int r)
        {
            int i = p, j = r, m = (i + j) / 2;
            Edge x = edge[m];

            do
            {
                while (edge[i].weight < x.weight)
                    i++;

                while (edge[j].weight > x.weight)
                    j--;

                if (i <= j)
                {
                    Edge temp = edge[i];

                    edge[i] = edge[j];
                    edge[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (p < j)
                QuickSort(ref edge, p, j);

            if (i < r)
                QuickSort(ref edge, i, r);
            
        }

        private int Find(Subset[] subsets, int i)
        {

            if (subsets[i].parent != i)
            {
                subsets[i].parent = Find(subsets, subsets[i].parent);
            }

            return subsets[i].parent;

        }

        private void Union(Subset[] subsets, int x, int y)
        {

            int xRoot = Find(subsets, x);
            int yRoot = Find(subsets, y);

            if (subsets[xRoot].parent < subsets[yRoot].parent)
            {
                subsets[xRoot].parent = yRoot;
            }
            else if (subsets[xRoot].parent > subsets[yRoot].parent)
            {
                subsets[yRoot].parent = xRoot;
            }
            else
            {
                subsets[yRoot].parent = xRoot;
                subsets[xRoot].rank++;
            }

        }
        #endregion

    }
}
