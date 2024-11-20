using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet__Partie_1
{
    class Transactions
    {
        public uint IdentifiantTransaction { get; private set;}
        public decimal Montant { get; set; }
        public uint IdentifiantExpéditeur { get; set; }
        public uint IdentifiantDestinataire { get; set; }
        public string StatutsTransaction { get; set; }
        public Type TypeDeTransaction { get; set; }

        public Transactions(uint identifiantTransaction, decimal montant, uint identifiantExpéditeur, uint identifiantDestinataire)
        {
            IdentifiantTransaction = identifiantTransaction;
            Montant = montant;
            IdentifiantExpéditeur = identifiantExpéditeur;
            IdentifiantDestinataire = identifiantDestinataire;
            StatutsTransaction = "KO";
        }
        public enum Type
        {
            Dépot,
            Retrait,
            Virement
        }
    
    }
}
