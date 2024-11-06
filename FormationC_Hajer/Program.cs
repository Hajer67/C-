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
            BasicOperation(3, 4, '+');
            BasicOperation(3, 0, '/');
            BasicOperation(3, 4, 'L');

            Console.WriteLine(" ");

            IntegerDivision(12, 4);
            IntegerDivision(13, 4);
            IntegerDivision(12, 0);

            Console.WriteLine(" ");

            Pow(5, 2);
            Pow(5, -2);

            Console.ReadKey();
        }

        static void BasicOperation(int a, int b, char operateur)
        {
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
            int résultat;

            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = opération invalide.");
            }

            else
            {
                résultat = a ^ b;


                {
                    Console.WriteLine($"{a} ^ {b} = {résultat} ");
                }


            }
        }
    }
        
}



