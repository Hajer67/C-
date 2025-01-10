using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Projet_partie_2
{
    internal class EntréesSorties
    {
        public static Dictionary <uint, CompteBancaire> FichierComptes(string fichierComptes)
        {
            if (!File.Exists(fichierComptes))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", fichierComptes);
            }
            Dictionary <uint, CompteBancaire> comptes = new Dictionary <uint, CompteBancaire>();

            using (FileStream fsComptes = File.OpenRead(fichierComptes))
            using (StreamReader lectureComptes = new StreamReader(fsComptes))
            {
                while (!lectureComptes.EndOfStream)
                {
                    decimal solde;
                    string[] lignesComptes = lectureComptes.ReadLine().Split(';');
                    CultureInfo fr = new CultureInfo("fr-FR");
                    DateTime date;
                    uint entrée;
                    uint sortie;

                    if (lignesComptes.Length != 5)
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : Le format de la ligne n'est pas correct.");
                        continue;
                    }
                    if (lignesComptes[2] == string.Empty)
                    {
                        solde = 0;
                    }
                    else if (!decimal.TryParse(lignesComptes[2], out solde))
                    {
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
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant du compte demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant d'un compte ne peut pas être égal à zéro.");
                        continue;
                    }
                    if (!DateTime.TryParseExact(lignesComptes[1],"d",fr,DateTimeStyles.None, out date))
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : La date renseignée est incorrecte.");
                        continue;
                    }
                    if (!uint.TryParse(lignesComptes[3], out uint identifiant))
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant du gestionnaire en entrée demandé n'existe pas.");
                        continue;
                    }
                     if (!uint.TryParse(lignesComptes[4], out uint identifiant))
                    {
                        Console.WriteLine($"Compte {lignesComptes[0]} : L'identifiant du gestionnaire en sortie demandé n'existe pas.");
                        continue;
                    }
                    if (comptes.ContainsKey(identifiant))
                    {
                        continue;
                    }
                    else
                    {
                        comptes.Add(identifiant, new CompteBancaire(identifiant, solde, nombreTransactionsMax, date));
                    }
                }
                return comptes;
            }
        }

        public static Dictionary <uint, Transactions> FichierTransactions(string fichierTransactions)
        {
            if (!File.Exists(fichierTransactions))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", fichierTransactions);
            }

            Dictionary <uint, Transactions> transactions = new Dictionary <uint, Transactions>();

            using (FileStream fsTransactions = File.OpenRead(fichierTransactions))
            using (StreamReader lectureTransactions = new StreamReader(fsTransactions))
            {
                while (!lectureTransactions.EndOfStream)
                {
                    decimal montant;
                    string[] lignesTransactions = lectureTransactions.ReadLine().Split(';');
                    CultureInfo fr = new CultureInfo("fr-FR");
                    DateTime dateEffet;

                    if (lignesTransactions.Length != 5)
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le format de la ligne n'est pas correct : {lignesTransactions.Length}");
                        continue;
                    }
                    if (lignesTransactions[1] == string.Empty)
                    {
                        montant = 0;
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le montant de la transaction ne peut pas être égal à zéro : {lignesTransactions[1]}");
                    }
                    else if (!decimal.TryParse(lignesTransactions[2], out montant))
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
                    if (!DateTime.TryParseExact(lignesTransactions[1],"d",fr,DateTimeStyles.None, out dateEffet))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : La date renseignée est incorrecte.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[3], out uint expéditeur))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : L'expéditeur demandé n'existe pas.");
                        continue;
                    }
                    if (!uint.TryParse(lignesTransactions[4], out uint destintaire))
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
                        transactions.Add(identifiant, new Transactions(identifiant, montant, expéditeur, destintaire, dateEffet));
                    }
                }
                return transactions;
            }

        }

         public static Dictionary<uint, Gestionnaire> FichierGestionnaires(string fichierGestionnaires)
        {
            if (!File.Exists(fichierGestionnaires))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", fichierGestionnaires);
            }

            Dictionary <uint, Gestionnaire> gestionnaires = new Dictionary <uint, Gestionnaire>();

            using (FileStream fsGestionnaires = File.OpenRead(fichierGestionnaires))
            using (StreamReader lectureGestionnaires = new StreamReader(fsGestionnaires))
            {
                while (!lectureGestionnaires.EndOfStream)
                {
                    List <string> gestionnaireValide = new List <string> ("Particulier","Entreprise");
                    string[] lignesGestionnaires = lectureGestionnaires.ReadLine().Split(';');
                   
                    if (lignesGestionnaires.Length != 3)
                    {
                        Console.WriteLine($"Gestionnaire {lignesGestionnaires[0]} : Le format de la ligne n'est pas correct : {lignesGestionnaires.Length}");
                        continue;
                    }

                    if (lignesGestionnaires[1] == string.Empty || !string.TryParse(lignesGestionnaires[1], out string type))
                    {
                        Console.WriteLine($"Gestionnaire {lignesGestionnaires[0]} : Le gestionnaire demandé ne possède pas de type.");
                        continue;
                    }

                    if (!gestionnaireValide.Find(x => x.Equals(lignesGestionnaires[1]))
	                {
                        Console.WriteLine($"Gestionnaire {lignesGestionnaires[0]} : Le gestionnaire ne possède pas de type valide.");
                        continue;
	                }
	               
                    if (!uint.TryParse(lignesGestionnaires[0], out uint identifiant))
                    {
                        Console.WriteLine($"Gestionnaire {lignesGestionnaires[0]} : L'identifiant du gestionnaire demandé n'existe pas.");
                        continue;
                    }
                    if (identifiant == 0)
                    {
                        Console.WriteLine($"Gestionnaire {lignesGestionnaires[0]} : L'identifiant d'un gestionnaire ne peut pas être égal à zéro.");
                        continue;
                    }

                    if (!uint.TryParse(lignesTransactions[2], out uint nombreTransactions))
                    {
                        Console.WriteLine($"Transaction {lignesTransactions[0]} : Le nombre de transactions n'est pas valide");
                        continue;
                    }

                    if (gestionnaires.ContainsKey(identifiant))
                    {
                        continue;
                    }
                    else
                    {
                        gestionnaires.Add(identifiant, new Gestionnaire(identifiant, type, nombreTransactions));
                    }
                }
                return gestionnaires; 
            }

         }

        public static void fichierStatusTransactions(Dictionary <uint, Transactions> statutsTransactions)
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

