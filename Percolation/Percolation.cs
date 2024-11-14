using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Formation C#
//                        PERCOLATION
//                        14/11/2024
// Hajer BEN HAMOUDA


namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i, j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i, j];
        }

        public bool Percolate()
        {
            int i = _full.Length - 1;
            for (int j=0 ; j < _full.Length - 1; j++)
            {
                if (_full[i,j] == true)
                {
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j) 
        {
            List<KeyValuePair<int, int>> Voisins = new List<KeyValuePair<int, int>>();

            if (i-1 > 0)
            {
                Voisins.Add(new KeyValuePair<int, int>(i-1 , j));
            }
            if (i+1 < _size -1)
            {
                Voisins.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            if (j-1 > 0)
            {
                Voisins.Add(new KeyValuePair<int, int>(i, j -1));
            }
            if (j+1 < _size - 1)
            {
                Voisins.Add(new KeyValuePair<int, int>(i, j +1));
            }
            return Voisins;
        }

        public void Open(int i, int j)
        {

        }

     //------------------------------ EXERCICE -----------------------------//

     // 3). (b)
     // Dans le pire des cas, cette méthode va entraîner une ouverture en 
     // en cascade de toutes les cases adjacentes et donc faire appel à 
     // la fonction Open de manière réccurente et donc la performance de
     // cette méthode sera mauvaise.

     // 3). (c)
     // Ce cas de figure a peu de chances de se produire car les cases de
     // la grille qui sont initialement fermées sont ouvertes au fur et à 
     // mesure de manière aléatoire. Il y a donc peu de chance que les cases
     // s'ouvrent de manière adjacente.


   












    }


}
