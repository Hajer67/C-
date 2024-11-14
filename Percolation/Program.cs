using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            Percolation test = new Percolation(5);
            List<KeyValuePair<int, int>> voisins = test.CloseNeighbors(2, 2);
            for (int i = 0; i < voisins.Count; i++)
            {
                Console.Write("ligne : " + voisins[i].Key + " ");
                Console.Write("colonne : " + voisins[i].Value + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
