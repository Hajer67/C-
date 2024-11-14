using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            double somme = 0;
            double moyenne = 0;

            for (int i = 0; i < t; i++)
            {
                somme += PercolationValue(size);
            }
            moyenne = somme / t;

            double variance = 0;
            double ecartType = 0;

            for (int i = 0; i < t; i++)
            {
                variance = +PercolationValue(size) * PercolationValue(size); 
            }
            ecartType = Math.Sqrt(variance - moyenne * moyenne);
        }   


        public double PercolationValue(int size)
        {
            Percolation cases = new Percolation(size);

            Random entier = new Random();
            int compteur = 0;
            while (!cases.Percolate()) 
            {
                int i = entier.Next(0, size);
                int j = entier.Next(0, size);

                while (cases.IsOpen(i,j))     // Cette boucle permet de
                {                             // générer des entiers qui
                    i = entier.Next(0, size); // permettent de ne pas "ouvrir"
                    j = entier.Next(0, size); // des cases déjà ouvertes.
                }

                cases.Open(i, j);  // La fonction Open permet d'ouvrir une 
                                   // case [i,j] de manière aléatoire, ainsi
                compteur++;        // que les cases voisines de celle-ci.
            }
            double fraction = (double)compteur / (size * size);
            return fraction;
        }
    }
}
