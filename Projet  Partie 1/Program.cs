using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet__Partie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();
            banque.GestionTransactions();
            Console.ReadKey();
        }
    }
}