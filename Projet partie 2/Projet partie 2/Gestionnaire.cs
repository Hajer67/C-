using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_partie_2
{
    internal class Gestionnaire
    {
        public uint Identifiant { get; private set; }
        public string Type { get; private set; }
        public int NombreTransactionsMax { get; private set; }
        public decimal FraisGestion { get; set; }
    }
}
