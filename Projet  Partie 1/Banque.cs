using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet__Partie_1
{
    class Banque
    {
        private Dictionary<uint, CompteBancaire> _comptes;
        private Dictionary<uint, Transactions> _transactions;

        public Banque()
        {
            _comptes = EntréeSortie.FichierComptes();
            _transactions = EntréeSortie.FichierTransactions(@"C:\Users\User\Documents\Entrée\Transactions.csv");
        }

        public void GestionTransactions()
        {
            foreach (var transaction in _transactions)
            { 
                GestionTransaction(transaction.Value);
            }
            EntréeSortie.fichierStatusTransactions(_transactions);
        }

        private bool GestionTransaction(Transactions transaction)
        {
            if (transaction.IdentifiantExpéditeur == 0 && transaction.IdentifiantDestinataire == 0)
            {
                Console.WriteLine("Expéditeur et destinataire inexistants.");
                return false;
            }
            else if (transaction.IdentifiantDestinataire == 0)
            {
                return GestionRetrait(transaction, _comptes[transaction.IdentifiantExpéditeur]);
               
            }
            else if (transaction.IdentifiantExpéditeur == 0)
            {
                return GestionDépot(transaction, _comptes[transaction.IdentifiantDestinataire]);
            }
            else
            {
                return GestionVirement(transaction, _comptes[transaction.IdentifiantDestinataire], _comptes[transaction.IdentifiantExpéditeur]);
            }

        }

        private bool GestionRetrait(Transactions retrait, CompteBancaire compte)
        {
            retrait.TypeDeTransaction = Transactions.Type.Retrait;
            if (compte.IsWithdrawalValid(retrait.Montant)) 
            {
                compte.Withdrawal(retrait.Montant);
                retrait.StatutsTransaction = "OK";
                return true;
            }
            return false;
        }

        private bool GestionDépot(Transactions dépot, CompteBancaire compte)
        {
            dépot.TypeDeTransaction = Transactions.Type.Dépot;
            if (compte.IsDepositValid(dépot.Montant))
            {
                compte.Deposit(dépot.Montant);
                dépot.StatutsTransaction = "OK";
                return true;
            }
            return false;
        }
        private bool GestionVirement(Transactions virement, CompteBancaire destinataire, CompteBancaire expéditeur)
        {
            virement.TypeDeTransaction = Transactions.Type.Virement;
            if (destinataire.IsDepositValid(virement.Montant) && expéditeur.IsWithdrawalValid(virement.Montant))
            {
                destinataire.Deposit(virement.Montant);
                expéditeur.Withdrawal(virement.Montant);
                virement.StatutsTransaction = "OK";
                return true;
            }
            return false;
        }

    }
}
