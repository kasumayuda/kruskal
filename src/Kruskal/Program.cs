using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kruskal
{
    public class Program
    {

        private static void RunKruskal(int V, int E, List<int> sources, List<int> destinations, List<int> weights)
        {

            Graph graph = new Graph(V, E);
            for (int i = 0; i < E; i++)
            {
                graph.edge[i].source = sources[i];
                graph.edge[i].destination = destinations[i];
                graph.edge[i].weight = weights[i];
            }

            graph.Kruskal();

        }

        public static void Main(string[] args)
        {
            int V; //node
            int E; //edge            
            List<int> sources = null;
            List<int> destinations = null;
            List<int> weights = null;
                        
            V = 4;
            E = 5;
            sources = new List<int>() { 0,0,0,1,2 };
            destinations = new List<int> { 1,2,3,3,3 };
            weights = new List<int> { 10,6,5,15,4 };
            RunKruskal(V, E, sources, destinations, weights);

            Console.WriteLine("==============================");

            V = 7;
            E = 11;
            sources = new List<int>() { 0, 0, 1, 1, 2, 1, 3, 3, 4, 4, 5 };
            destinations = new List<int>() { 1, 3, 2, 4, 4, 3, 4, 5, 5, 6, 6 };
            weights = new List<int>() { 7, 5, 8, 7, 5, 9, 15, 6, 8, 9, 11 };
            RunKruskal(V, E, sources, destinations, weights);

        }
    }
}
