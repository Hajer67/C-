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

        private const decimal _maxRetrait = 2000;
        private const DateTime.Equals(_dateCréation,_dateRésiliation)
        private DateTime _dateCréation;
        private DateTime _dateRésiliation;
        private List<decimal> _historiqueRetrait;

        public CompteBancaire(uint identifiantCompte, decimal solde)
        {
            IdentifiantCompte = identifiantCompte;
            Solde = solde;
            _historiqueRetrait = new List<decimal>();
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
            if (montant <= 0 || Solde < montant || SommeRetraits(montant) >= _maxRetrait)
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

