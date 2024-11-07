using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationC_Hajer
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Exercice 1 - Opérations élémentaires ");
            Console.WriteLine(" ");

            Console.WriteLine("Opérations de base : ");
            BasicOperation(3, 4, '+');
            BasicOperation(3, 0, '/');
            BasicOperation(3, 4, 'L');

            Console.WriteLine(" ");

            Console.WriteLine("Division entière : ");
            IntegerDivision(12, 4);
            IntegerDivision(13, 4);
            IntegerDivision(12, 0);

            Console.WriteLine(" ");

            Console.WriteLine("Puissance entière : ");
            Pow(5, 2);
            Pow(5, -2);

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Exercice 2 - Horloge parlante ");
            Console.WriteLine(" ");

            GoodDay(1);
            GoodDay(10);
            GoodDay(12);
            GoodDay(15);
            GoodDay(20);
            GoodDay(25);

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Exercice 3 - Construction pyramide ");
            Console.WriteLine(" ");

            PyramidConstruction(10, true);
            Console.WriteLine(" ");
            PyramidConstruction(10, false);


            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Exercice 4 - Factorielle ");
            Console.WriteLine(" ");

            Console.WriteLine($" {5}! = {FactorialIt(5)} ");
            Console.WriteLine(" ");
            Console.WriteLine($" {5}! = {FactorialRec(5)} ");


            Console.ReadKey();

        }

        // EXERCICE I - OPERATIONS ELEMENTAIRES

        static void BasicOperation(int a, int b, char operateur)
        {
            // Opérations de base : 
            int r;
            //char operateur = { +, -, *,/};
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

        




    }

        
}



