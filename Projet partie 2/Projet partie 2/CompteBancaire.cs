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
        private const decimal _maxRetraitHebdomadaire = 2000;
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

        private decimal SommeRetraits(decimal retrait)
        {
            decimal sommeRetraits = retrait;
            for (int i = 0; i < NombreTransactionsMax - 1 && i <_historiqueRetrait.Count(); i++)
            {
                sommeRetraits += _historiqueRetrait[i];
            }

            foreach (decimal montant in _historiqueRetrait)
            {
                sommeRetraits += montant;
            }
            return sommeRetraits;
        }

        public bool RetraitMaxAtteint(decimal retrait)
        {
            decimal totalRetrait = SommeRetraits(retrait);

            if (totalRetrait > _maxRetrait)
            {
                return true;
            }
            return false;
        }


        private decimal SommeRetraitsHebdomadaire(decimal montant, DateTime dateEffet)
        {
            decimal sommeRetraitsHebdomadaire = montant;
        
            foreach (KeyValuePair<decimal, DateTime> retrait in _historiqueHebdomadaire)
            {
                if (retrait.Value <= dateEffet && dateEffet - retrait.Value < _periodeRetraitMax && retrait.Value >= DateCréation && retrait.Value < DateRésiliation)
                {
                    sommeRetraitsHebdomadaire += retrait.Key;
                }
            }
            return sommeRetraitsHebdomadaire;
        }

        public bool RetraitHebdomadaireMaxAtteint(decimal retrait, DateTime dateEffet)
        {
            decimal totalRetraitHebdomadaire = SommeRetraitsHebdomadaire(retrait, dateEffet);

            if (totalRetraitHebdomadaire > _maxRetraitHebdomadaire)
            {
                return true;
            }
            return false;
        }

        private void NouveauRetrait(decimal montant)
        {
            if (NombreTransactionsMax != 1)
            {
                if (_historiqueRetrait.Count() < NombreTransactionsMax - 1)
                {
                    _historiqueRetrait.Add(montant);
                }
                else if (_historiqueRetrait.Count() == NombreTransactionsMax - 1)
                {
                    _historiqueRetrait.RemoveAt(0);
                    _historiqueRetrait.Add(montant);
                }
                else
                {
                    while (_historiqueRetrait.Count() >= NombreTransactionsMax - 1)
                    {
                        _historiqueRetrait.RemoveAt(0);
                    }
                    _historiqueRetrait.Add(montant);
                }
            }  
        }

        private void NouveauRetraitsHebdomadaire(decimal retrait, DateTime dateEffet)
        {
            _historiqueHebdomadaire.Add(retrait, dateEffet);
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

        public void Withdrawal(decimal montant, DateTime dateEffet)
        {
            Solde -= montant;
            NouveauRetrait(montant);
            NouveauRetraitsHebdomadaire(montant, dateEffet);
        }

    }
}

