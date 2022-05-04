using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCSharpApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Antarpreet Singh";

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}: Version - {1} by {2}", appName, appVersion, appAuthor);
            Console.ForegroundColor = ConsoleColor.Black;

            string name = inputName();

            bool check = false;
            int[] limits;
            do
            {
                check = false;
                limits = setLimits();
                limits[1] += 1;

                if(limits[0] >= limits[1])
                {
                    Console.WriteLine("Invalid! Lower limit cannot be greater than the upper limit.");
                    check = true;   
                }
            } while (check == true);
            
            
            int num = (limits[0] + limits[1])/2;
            guesser(limits, num, name);
        }
        static string inputName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " let's play a game");
            return name;
        }
        static int[] setLimits()
        {
            int[] numbers;
            numbers = new int[2];
            Console.WriteLine("Choose an upper limit - (inclusive)");
            numbers[1] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Choose a lower limit - (inclusive)");
            numbers[0] = Int32.Parse(Console.ReadLine());

            return numbers;
        }

        static int guesser(int[] limits, int n, string name)
        {
            if (limits[0] == (limits[1] - 2))
            {
                Console.WriteLine("Your number is " + n + " !!!!!");
                Console.WriteLine("It was fun playing with you " + name);
                return 0;
            }

            bool checker = false;

            do
            {
                Console.WriteLine("Is your number " + n + " ?");
                Console.WriteLine("Yes - Y, No - N");
                string input = Console.ReadLine();

                if (input == "Y")
                {
                    Console.WriteLine("Yay! It was fun playing with you " + name);
                    checker = false;
                }
                else if (input == "N")
                {
                    bool secondChecker = false;
                    do
                    {
                        Console.WriteLine("Is your number greater [G] is lesser [L] than " + n);
                        input = Console.ReadLine();
                        if (input == "G")
                        {
                            int[] newLimits;
                            newLimits = limits;
                            newLimits[0] = n;
                            int nn = (newLimits[0] + newLimits[1]) / 2;
                            guesser(newLimits, nn, name);
                            break;
                        }
                        else if (input == "L")
                        {
                            int[] newLimits;
                            newLimits = limits;
                            newLimits[1] = n;
                            int nn = (newLimits[0] + newLimits[1]) / 2;
                            guesser(newLimits, nn, name);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            secondChecker = true;                        
                        }
                    } while (secondChecker);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    checker = true;
                }
            } while (checker);
            return 0;   
        }
    }
}
