using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_partie_2
{
    internal class CompteBancaire
    {
        public uint IdentifiantCompte { get; private set; }
        public decimal Solde { get; private set; }
        public DateTime DateRésiliation { get; set; }
        public DateTime DateCréation { get; set; }
        public uint NombreTransactionsMax { get; set; }

        private const decimal _maxRetrait = 1000;
        private TimeSpan _periodeRetraitMax = new TimeSpan(7, 0, 0, 0);
        private List<decimal> _historiqueRetrait;
        private Dictionary<decimal, DateTime> _historiqueHebdomadaire;

        public CompteBancaire(uint identifiantCompte, decimal solde, uint nombreTransactionsMax, DateTime dateCréation)
        {
            IdentifiantCompte = identifiantCompte;
            Solde = solde;
            _historiqueRetrait = new List<decimal>();
            NombreTransactionsMax = nombreTransactionsMax;
            DateCréation = dateCréation;
            DateRésiliation = DateTime.MaxValue;
            _historiqueHebdomadaire= new Dictionary<decimal, DateTime>();
        }

        private decimal SommeRetraits(decimal transaction)
        {
            decimal sommeRetraits = transaction;

            foreach (decimal montant in _historiqueRetrait)
            {
                sommeRetraits += montant;
            }
            return sommeRetraits;
        }

      /*  private decimal SommeRetraitsHebdomadaire(decimal transaction) 
        {
            decimal sommeRetraits 
        }
      */

        private void NouveauRetrait(decimal montant)
        {
            if (_historiqueRetrait.Count < 9)
            {
                _historiqueRetrait.Add(montant);
            }
            else
            {
                _historiqueRetrait.RemoveAt(0);
                _historiqueRetrait.Add(montant);
            }
        }

        public bool IsDepositValid(Transactions transactions)
        {
            if (transactions.Montant <= 0 || transactions.DateEffet >= DateCréation || transactions.DateEffet < DateRésiliation)
            {
                return false;
            }
            return true;
        }

        public bool IsWithdrawalValid(Transactions transactions)
        {
            if (transactions.Montant <= 0 || Solde < transactions.Montant || transactions.DateEffet >= DateCréation || transactions.DateEffet < DateRésiliation )
            {
                return false;
            }
            return true;
        }

        public void Deposit(decimal montant)
        {
            Solde += montant;
        }

        public void Withdrawal(decimal montant)
        {
            Solde -= montant;
            NouveauRetrait(montant);
        }

    }
}

