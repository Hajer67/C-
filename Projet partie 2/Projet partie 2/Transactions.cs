using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_partie_2
{
    internal class Transactions
    {
        public uint IdentifiantTransaction { get; private set; }
        public decimal Montant { get; set; }
        public uint IdentifiantExpéditeur { get; set; }
        public uint IdentifiantDestinataire { get; set; }
        public string StatutsTransaction { get; set; }
        public Type TypeDeTransaction { get; set; }
        public DateTime DateEffet { get; set; }

        public Transactions(uint identifiantTransaction, decimal montant, uint identifiantExpéditeur, uint identifiantDestinataire, DateTime dateEffet)
        {
            IdentifiantTransaction = identifiantTransaction;
            Montant = montant;
            IdentifiantExpéditeur = identifiantExpéditeur;
            IdentifiantDestinataire = identifiantDestinataire;
            StatutsTransaction = "KO";
            DateEffet = dateEffet;
        }
        public enum Type
        {
            Dépot,
            Retrait,
            Virement
        }

    }
}

