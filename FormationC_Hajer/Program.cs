using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FormationC_Hajer
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("SERIE I ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercice 1 - Opérations élémentaires ");
            Console.WriteLine();

            Console.WriteLine("Opérations de base : ");
            BasicOperation(3, 4, '+');
            BasicOperation(3, 0, '/');
            BasicOperation(3, 4, 'L');

            Console.WriteLine();

            Console.WriteLine("Division entière : ");
            IntegerDivision(12, 4);
            IntegerDivision(13, 4);
            IntegerDivision(12, 0);

            Console.WriteLine();

            Console.WriteLine("Puissance entière : ");
            Pow(5, 2);
            Pow(5, -2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercice 2 - Horloge parlante ");
            Console.WriteLine();

            GoodDay(1);
            GoodDay(10);
            GoodDay(12);
            GoodDay(15);
            GoodDay(20);
            GoodDay(25);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercice 3 - Construction pyramide ");
            Console.WriteLine();

            PyramidConstruction(10, true);
            Console.WriteLine();
            PyramidConstruction(10, false);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercice 4 - Factorielle ");
            Console.WriteLine();

            Console.WriteLine($" {5}! = {FactorialIt(5)} ");
            Console.WriteLine();
            Console.WriteLine($" {5}! = {FactorialRec(5)} ");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("SERIE II ");
            Console.WriteLine();
            Console.WriteLine("Exercice 1 - Recherche d'un élément ");
            Console.WriteLine();

            int[] tableau = new int[] { -7, -5, -3, 0, 1, 2, 3, 4, 10};
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.Write(tableau[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Recherche linéaire : ");
            Console.WriteLine($" {2} --> indice : {LinearSearch(tableau, 2)} ");
            Console.WriteLine($" {8} --> non trouvé : {LinearSearch(tableau, 8)} ");
            Console.WriteLine();
            Console.WriteLine("Recherche dichotomique : ");
            Console.WriteLine($" {2} --> indice : {BinarySearch(tableau, 2)} ");
            Console.WriteLine($" {8} --> non trouvé : {BinarySearch(tableau, 8)} ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercice 2 : Bases du calcul matriciel ");
            Console.WriteLine();
            Console.WriteLine("Construction matricielle : ");

            int[] leftVector = { 1, 2, 3};
            int[] rightVector = { -1, -4, 0 };
            int[][] mRes = BuildingMatrix(leftVector, rightVector);

            DisplayMatrix(mRes);

            Console.WriteLine();
            Console.WriteLine("Addition matricielle : ");
            int[][] leftMatrix = {new int[] { 1, 2 }, new int[] { 4, 6 }, new int[] { -1, 8 } };
            int[][] rightMatrix = { new int[] { -1, 5 }, new int[] { -4, 0 }, new int[] { 0, 2 } };

            DisplayMatrix(Addition(leftMatrix,rightMatrix));

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Soustraction matricielle : ");

            DisplayMatrix(Substraction(leftMatrix, rightMatrix));

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Multiplication matricielle : ");
            int[][] leftMatrixMult = { new int[] { 1, 2 }, new int[] { 4, 6 }, new int[] { -1, 8 } };
            int[][] rightMatrixMult = { new int[] { -1, 5, 0 }, new int[] { -4, 0, 1 } };

            try
            {
                DisplayMatrix(Multiplication(leftMatrixMult, rightMatrixMult));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("SERIE III ");
            Console.WriteLine();
            Console.WriteLine("Exercice 1 - Conseil de classe ");
            Console.WriteLine();

            try
            {
                SchoolMeans(@"C:\Users\User\Desktop\Formation C#\C-\FormationC_Hajer\Notes.csv", @"C:\Users\User\Desktop\Formation C#\C-\FormationC_Hajer\Moyenne.csv");
                Console.WriteLine("Execution réussie, fichier Moyenne créé.");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("SERIE IV ");
            Console.WriteLine();
            Console.WriteLine("Exercice 2 - Contrôle des parenthèses ");
            Console.WriteLine();
            string sentence = "{Gaetan préfère le COBOL (c'est dur le C# !) Il s'écria [Irridia me manque...]}";
            if (BracketsControls(sentence))
            {
                Console.WriteLine(sentence);
            }
            else
            {
                Console.WriteLine("Relis ta phrase et refléchis avant d'écrire !");
            }
            Console.WriteLine();

            Console.ReadKey();

        }

        // ------------------------ SERIE I --------------------------- //

        // EXERCICE I - OPERATIONS ELEMENTAIRES

        static void BasicOperation(int a, int b, char operateur)
        {
            // Opérations de base : 
            int r;
            // Operateurs = { +, -, *,/};
            switch (operateur)
            {
                case '+':
                    r = a + b;
                    Console.WriteLine($"{a} {operateur} {b} = {r} ");
                    break;

                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine($"{a} {operateur} {b} = opération invalide.");
                        break;
                    }
                    else
                    {
                        r = a / b;
                        Console.WriteLine($"{a} {operateur} {b} = {r} ");
                        break;
                    }

                case '-':
                    r = a - b;
                    Console.WriteLine($"{a} {operateur} {b} = {r} ");
                    break;

                case '*':
                    r = a * b;
                    Console.WriteLine($"{a} {operateur} {b} = {r} ");
                    break;

                default:
                    Console.WriteLine($"{a} {operateur} {b} = opération invalide.");
                    break;

            }
        }

        static void IntegerDivision(int a, int b)
        {
            // Division entière :

            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = opération invalide.");
            }
            else
            {
                int q = a / b;
                int r = a % b;

                a = q * b + r;

                if (r == 0)
                {
                    Console.WriteLine($"{a} = {q} * {b} ");
                }
                else
                {
                    Console.WriteLine($"{a} = {q} * {b} + {r}");
                }
            }
        }


        static void Pow(int a, int b)
        {
            // Puissance entière :

            int résultat;

            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = opération invalide.");
            }
            else
            {
                résultat = (int)Math.Pow(a, b);
                {
                    Console.WriteLine($"{a} ^ {b} = {résultat} ");
                }
            }
        }


        // EXERCICE II - HORLOGE PARLANTE

       
        static void GoodDay(int heure)
        {
            if (0 <= heure && heure < 6) 
            {
                Console.WriteLine($"Il est {heure} H, Merveilleuse nuit !");
            }
            else if (6 <= heure && heure < 12) 
            {
                Console.WriteLine($"Il est {heure} H, Bonne matinée !");
            }
            else if (heure == 12)
            {
                Console.WriteLine($"Il est {heure} H, Bon appétit !");
            }
            else if (13 <= heure && heure <= 18)
            {
                Console.WriteLine($"Il est {heure} H, Profitez de votre après-midi !");
            }
            else if (heure > 18 && heure < 24)
            {
                Console.WriteLine($"Il est {heure} H, Passez une bonne soirée !");
            }
            else 
            {
                Console.WriteLine($"Il n'est pas {heure} H, Apprenez à compter svp !");
            }
        }

        // EXERCICE III - CONSTRUCTION D'UNE PYRAMIDE

        static void PyramidConstruction(int n, bool isSmooth)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i <= (2 * n +1); i++)
                {
                    if (i < (n - j))
                    {
                        Console.Write(" ");
                    }                  
                    else if (i >= (n -j) && i <= (n +j))
                    {
                        if (!isSmooth)
                        {
                            if (j % 2 == 1)
                            {
                                Console.Write("+");
                            }                           
                            else
                            {
                                Console.Write("-");
                            }
                        }
                        else
                        {
                            Console.Write("+");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        // EXERCICE IV - FACTORIELLE

        // Méthode itérative
        static int FactorialIt(int n)
        {
            int F = 1;

            if (n == 0)
            {
                return 1;

            }

            for (int i = 1; i <= n ; i++)
            {
                F *= i;
            }
            return F;
        }

        // Méthode récursive

        static int FactorialRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * FactorialRec(n - 1);     
        }

      // ------------------------ SERIE II --------------------------- //

      // EXERCICE I - RECHERCHE D'UN ELEMENT

        // Recherche linéaire :
        static int LinearSearch(int [] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if (valeur == tableau[i])
                {
                    return i;   // Valeur trouvée
                }          
            }
            return -1;   // Valeur non trouvée
        }

        // Recherche dichotomique :

        static int BinarySearch(int [] tableau, int valeur)
        {
            int Igauche = 0;
            int Idroite = tableau.Length - 1;
            int milieu = ((Igauche + Idroite) / 2);

            while (Igauche <= Idroite )
            {
                milieu = ((Igauche + Idroite) / 2);

                if ( valeur == tableau [milieu] )
                {
                    return milieu;  // Valeur trouvée
                }
                else if ( valeur < tableau [milieu] )
                {
                    Idroite = milieu - 1;

                }
                else if ( valeur > tableau [milieu] )
                {
                    Igauche = milieu + 1;
                    milieu = ((Igauche + Idroite) / 2);
                }               
                else
                {
                    return -1;   // Valeur non trouvée
                }           
            }
            return -1;   // Valeur non trouvée
        }

        // EXERCICE II - BASES DU CALCUL MATRICIEL

        // Construction matricielle : 

        static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[][] mRes = new int [leftVector.Length][];

            for (int i = 0; i < leftVector.Length; i++)
            {
                mRes[i] = new int[rightVector.Length];

                for (int j = 0; j < rightVector.Length; j++)
                {
                    mRes[i][j] = rightVector[j] * leftVector[i];
                   
                }
            }
            return mRes;
        }

        static void DisplayMatrix(int[][] matrice)
        {
            int lignes = matrice.Length;
            int cols = matrice[0].Length;

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write((matrice[i][j]) + " ");
                }
                Console.WriteLine();
            }
        }

        //  Addition matricielle :

        static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] mRes = new int[leftMatrix.Length][];

            for (int i = 0; i < rightMatrix.Length; i++)
            {
                mRes[i] = new int[rightMatrix[0].Length];

                for (int j = 0; j < rightMatrix[0].Length; j++)
                {
                    mRes[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                }          
            }
            return mRes;
        }

        //  Soustraction matricielle :

        static int[][] Substraction(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] mRes = new int[leftMatrix.Length][];

            for (int i = 0; i < rightMatrix.Length; i++)
            {
                mRes[i] = new int[rightMatrix[0].Length];

                for (int j = 0; j < rightMatrix[0].Length; j++)
                {
                    mRes[i][j] = leftMatrix[i][j] - rightMatrix[i][j];
                }
            }
            return mRes;
        }

        //  Multiplication matricielle :

        static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {
            int lignesLeft = leftMatrix.Length;
            int colsLeft = leftMatrix[0].Length;
            int lignesRight = rightMatrix.Length;
            int colsRight = rightMatrix[0].Length;

            if ( colsLeft != lignesRight)
            {
                throw new ArgumentException($"Dimensions des matrices incompatibles leftMatrix : {colsLeft} et rightMatrix : {lignesRight}.");
            }

            int[][] mRes = new int[lignesLeft][];

            for (int i = 0; i < lignesLeft; i++)
            {
                mRes[i] = new int[colsRight];

                for (int j = 0; j < colsRight; j++)
                {
                    int somme = 0;
                    for (int k = 0; k < colsLeft; k++)
                    {
                        somme += leftMatrix[i][k] * rightMatrix[k][j];
                    }
                    mRes[i][j] = somme;
                }
            }
            return mRes; 
        }

        // ------------------------ SERIE III --------------------------- //

        // EXERCICE I - CONSEIL DE CLASSE
   
        static void SchoolMeans(string input, string output)
        {
            if (!File.Exists(input))
            {
                throw new FileNotFoundException("Fichier d'entrée non trouvé", input);
            }

            Dictionary<string, double> notes = new Dictionary<string, double>();
            Dictionary<string, int> compteurs = new Dictionary<string, int>();

            using (FileStream fs = File.OpenRead(input))
            using(StreamReader lecNotes =  new StreamReader(fs))
            {
                while(!lecNotes.EndOfStream)
                {
                    string[] lignesNotes = lecNotes.ReadLine().Split(';');
                    if(notes.ContainsKey(lignesNotes[1]))
                    {
                        notes[lignesNotes[1]] += double.Parse(lignesNotes[2]);
                        compteurs[lignesNotes[1]]++;
                    }
                    else
                    {
                        notes.Add(lignesNotes[1], double.Parse(lignesNotes[2]));
                        compteurs.Add(lignesNotes[1], 1);
                    }
                }
            }
            using(FileStream fsOut = File.Create(output))
            using (StreamWriter ecNotes = new StreamWriter(fsOut))
            {
                foreach (var note in notes)
                {
                    double moyenne = note.Value / compteurs[note.Key];
                    ecNotes.WriteLine($"{note.Key};{moyenne :##.0}");
                }
            }
        }

        // ------------------------ SERIE IV --------------------------- //

        // EXERCICE II - CONTRÔLE DES PARENTHESES

        static bool BracketsControls(string sentence)
        {
            Stack<char> parentèses = new Stack<char>();

            foreach (char charactère in sentence)
            {
                if (charactère == '(' || charactère == '{' || charactère == '[')
                {
                    parentèses.Push(charactère);
                }
                else if (charactère == ')' || charactère == '}' || charactère == ']')
                {
                    if (parentèses.Count == 0)
                    {
                        return false;
                    }

                    char open = parentèses.Pop();
                    if (open == '(' && charactère != ')')
                    {
                        return false;
                    }
                    else if (open == '{' && charactère != '}')
                    {
                        return false;
                    }
                    else if (open == '[' && charactère != ']')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    
        // Exercice III - Liste des contacts téléphoniques
    
        struct PhoneBook
        {
            private Dictionary<string, string> _annuaire; 

            bool IsValidPhoneNumber (string phoneNumber)
            {
                if (phoneNumber.Length != 10 || phoneNumber[0] != 0 || phoneNumber[1] == 0)
                {
                    return false;
                }
                foreach (char nombre in phoneNumber)
                {
                    if (!char.IsDigit(nombre))
                    {
                        return false;
                    }
                }
                return true;
            }
            bool ContainsPhoneContact(string phoneNumber)
            {
                return _annuaire.ContainsKey(phoneNumber);

            }
            void PhoneContact (string phoneNumber)
            {
                if (!_annuaire.ContainsKey(phoneNumber))
                {

                }

            }

        }
  
    }


}



