using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet__Partie_1
{
    class EntréeSortie
    {
        public static Dictionary<uint,CompteBancaire> FichierComptes (string comptes)
        {
            if (!File.Exists(comptes))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", comptes);
            }

            Dictionary<uint, CompteBancaire> compte = new Dictionary<uint, CompteBancaire>();

            using (FileStream fsComptes = File.OpenRead(comptes))
            using (StreamReader lecComptes = new StreamReader(fsComptes))
            {
                while (!lecComptes.EndOfStream)
                {
                    decimal solde;
                    string[] lignesComptes = lecComptes.ReadLine().Split(';');

                    if (lignesComptes.Length != 2)
                    { 
                        Console.WriteLine("Le format de la ligne n'est pas correct.");
                        continue;
                    }
                    if (lignesComptes[1] == string.Empty)
                    {
                       solde = 0;
                    }
                    else if (!decimal.TryParse(lignesComptes[1], out solde))
                    {
                        /*  foreach (char id in lignesComptes[0])
                          {
                              if (!char.IsDigit(id))
                              {
                                  Console.WriteLine("Un charactère non numérique dans l'identifiant a été détecté.");
                              }
                          }
                          foreach (char nombre in lignesComptes[1])
                          {
                              if (!char.IsDigit(nombre) && nombre != '.')
                              {
                                  Console.WriteLine("Un charactère non numérique dans le solde a été détecté.");
                              }
                          }*/
                        Console.WriteLine("Un charactère non numérique dans le solde a été détecté.");
                        continue;
                    }
                    if (solde < 0)
                    {
                        Console.WriteLine("Le solde ne peut pas être négatif.");
                        continue;
                    }
                    if (!uint.TryParse(lignesComptes[0], out uint identifiant))
                    {
                        Console.WriteLine("L'identifiant demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine("L'identifiant ne peut pas être égal à zéro.");
                        continue;
                    }

                    if (compte.ContainsKey(identifiant)) 
                    {
                        continue;
                    }
                    else
                    {
                        compte.Add(identifiant, new CompteBancaire(identifiant,solde));
                    }
                }
                return compte;
            }

        }


        public static Dictionary<uint, Transactions> FichierTransactions(string transactions)
        {
            if (!File.Exists(transactions))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", transactions);
            }

            Dictionary<uint, CompteBancaire> transaction = new Dictionary<uint, CompteBancaire>();

            using (FileStream fsTransactions = File.OpenRead(transactions))
            using (StreamReader lecTransactions = new StreamReader(fsTransactions))
            {
                while (!lecTransactions.EndOfStream)
                {
                    decimal montant;
                    string[] lignesTransactions = lecTransactions.ReadLine().Split(';');

                    if (lignesTransactions.Length != 4)
                    {
                        Console.WriteLine("Le format de la ligne n'est pas correct.");
                        continue;
                    }
                    if (lignesTransactions[1] == string.Empty)
                    {
                        montant = 0;
                        Console.WriteLine("Le montant de la transaction ne peut pas être égal à zéro.");
                    }
                    else if (!decimal.TryParse(lignesTransactions[1], out montant))
                    {
                        Console.WriteLine("Un charactère non numérique dans le montant de la transaction a été détecté.");
                        continue;
                    }
                    if (montant < 0)
                    {
                        Console.WriteLine("Le montant de la transaction ne peut pas être négatif.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[0], out uint identifiant))
                    {
                        Console.WriteLine("L'identifiant demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine("L'identifiant ne peut pas être égal à zéro.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[2], out uint expéditeur))
                    {
                        Console.WriteLine("L'expéditeur demandé n'existe pas.");
                        continue;
                    }
                    if (expéditeur == 0)
                    {
                        Console.WriteLine("L'esxpéditeur ne peut pas être égal à zéro.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[3], out uint destintaire))
                    {
                        Console.WriteLine("Le destinataire demandé n'existe pas.");
                        continue;
                    }
                    if (destintaire == 0)
                    {
                        Console.WriteLine("Le destinataire ne peut pas être égal à zéro.");
                        continue;
                    }

                    if (transaction.ContainsKey(identifiant))
                    {
                        continue;
                    }
                    else
                    {
                        transaction.Add(identifiant, new Transactions(identifiant, montant, expéditeur, destintaire));
                    }
                }
                return transaction;
            }

        }

    }

}
