using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_partie_2
{
    internal class Gestionnaire
    {
        public uint IdentifiantGestionnaire { get; private set; }
        public string Type { get; private set; }
        public int NombreTransactionsMax { get; private set; }
        public decimal FraisGestion { get; set; }
    
        private readonly Dictionary <uint, CompteBancaire> _comptes;

        public Gestionnaire(uint identifiantGestionnaire, string type, uint nombreTransactionsMax)
        {
            IdentifiantGestionnaire = identifiantGestionnaire;
            Type = type;
            NombreTransactionsMax = nombreTransactionsMax;
            FraisGestion = 0;
            _comptes = new Dictionary<uint, CompteBancaire>();
        }
    
        
    
    
    }




}
