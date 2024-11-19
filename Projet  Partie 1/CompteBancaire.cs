using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet__Partie_1
{
    class CompteBancaire
    {
        public uint Identifiant { get; private set; }

        public decimal Solde { get; private set; }
        
        private const decimal _maxRetrait = 1000;
        private List <decimal> _historiqueTransactions;
        
        public CompteBancaire(uint identifiant, decimal solde)
        {
            Identifiant = identifiant;
            Solde = solde;
            _historiqueTransactions = new List<decimal>();
        }

        public decimal SommeTransactions(decimal transaction)
        {
            decimal sommeTransactions = transaction;

            foreach (decimal montant in _historiqueTransactions)
            {
                sommeTransactions += montant;
            }
            return sommeTransactions;
        }
    
        private void NouvelleTransaction(decimal montant)
        {
            if (_historiqueTransactions.Count < 9)
            {
                _historiqueTransactions.Add(montant);
            }
            else
            {
                _historiqueTransactions.RemoveAt(0);
                _historiqueTransactions.Add(montant);
            }
        }
    
        public bool IsDepositValid(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }
            return true;
        }  
    
        public bool IsWithdrawalValid(decimal montant)
        {
            if (montant <= 0 || Solde < montant || SommeTransactions(montant) >= _maxRetrait)
            {
                return false;
            }
            return true;
        }
    
        public void 
    
    
    }
}
