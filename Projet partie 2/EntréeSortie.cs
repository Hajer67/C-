﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_Partie_2
{
    class EntréeSortie
    {
        public const string fichierComptes = @"C:\Users\Formation\Desktop\C#\PartieI\Comptes_1.txt";
        public static Dictionary<uint, CompteBancaire> FichierComptes()
        {
            if (!File.Exists(fichierComptes))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", fichierComptes);
            }
            Dictionary<uint, CompteBancaire> comptes = new Dictionary<uint, CompteBancaire>();

            using (FileStream fsComptes = File.OpenRead(fichierComptes))
            using (StreamReader lectureComptes = new StreamReader(fsComptes))
            {
                while (!lectureComptes.EndOfStream)
                {
                    decimal solde;
                    string[] lignesComptes = lectureComptes.ReadLine().Split(';');

                    if (lignesComptes.Length != 2)
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : Le format de la ligne n'est pas correct.");
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
                        Console.WriteLine($"Compte {lignesComptes[0]} : Un charactère non numérique dans le solde a été détecté.");
                        continue;
                    }
                    if (solde < 0)
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : Le solde ne peut pas être négatif.");
                        continue;
                    }
                    if (!uint.TryParse(lignesComptes[0], out uint identifiant))
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant ne peut pas être égal à zéro.");
                        continue;
                    }

                    if (comptes.ContainsKey(identifiant))
                    {
                        continue;
                    }
                    else
                    {
                        comptes.Add(identifiant, new CompteBancaire(identifiant, solde));
                    }
                }
                return comptes;
            }

        }

        public static Dictionary<uint, Transactions> FichierTransactions(string fichierTransactions)
        {
            if (!File.Exists(fichierTransactions))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", fichierTransactions);
            }

            Dictionary<uint, Transactions> transactions = new Dictionary<uint, Transactions>();

            using (FileStream fsTransactions = File.OpenRead(fichierTransactions))
            using (StreamReader lectureTransactions = new StreamReader(fsTransactions))
            {
                while (!lectureTransactions.EndOfStream)
                {
                    decimal montant;
                    string[] lignesTransactions = lectureTransactions.ReadLine().Split(';');

                    if (lignesTransactions.Length != 4)
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le format de la ligne n'est pas correct : {lignesTransactions.Length}");
                        continue;
                    }
                    if (lignesTransactions[1] == string.Empty)
                    {
                        montant = 0;
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le montant de la transaction ne peut pas être égal à zéro : {lignesTransactions[1]}");
                    }
                    else if (!decimal.TryParse(lignesTransactions[1], out montant))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Un charactère non numérique dans le montant de la transaction a été détecté.");
                        continue;
                    }
                    if (montant < 0)
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le montant de la transaction ne peut pas être négatif.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[0], out uint identifiant))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : L'identifiant demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : L'identifiant ne peut pas être égal à zéro.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[2], out uint expéditeur))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : L'expéditeur demandé n'existe pas.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[3], out uint destintaire))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le destinataire demandé n'existe pas.");
                        continue;
                    }
                    if (transactions.ContainsKey(identifiant))
                    {
                        continue;
                    }
                    else
                    {
                        transactions.Add(identifiant, new Transactions(identifiant, montant, expéditeur, destintaire));
                    }
                }
                return transactions;
            }

        }

        public static void fichierStatusTransactions(Dictionary<uint, Transactions> statutsTransactions)
        {
            using (FileStream fsOut = File.Create(@"C:\Users\Formation\Desktop\C#\PartieI\Statuts_b.txt"))
            using (StreamWriter ecritureTransactions = new StreamWriter(fsOut))
            {
                foreach (var statutsTransaction in statutsTransactions)
                {
                    ecritureTransactions.WriteLine($"{statutsTransaction.Key};{statutsTransaction.Value.StatutsTransaction}");
                }
            }
        }

    }

}
