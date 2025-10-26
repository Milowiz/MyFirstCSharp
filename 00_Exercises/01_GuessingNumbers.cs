using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _00_Exercises
{
    public class _01_GuessingNumber
    {
        public static void Run()
        {
            bool again;
            bool isVerified;
            Console.Clear();
            do
            {
                int versuche = 0;
                int inputNumber;
                int randomNumber = GenerateNumber(); // Zahl generieren
                do
                {
                    inputNumber = NumberInput();
                    isVerified = NumberVerification(inputNumber, randomNumber);
                    if (InvalidNumberRange(inputNumber) == true)
                    {
                        versuche++;
                    }
                }
                while (isVerified);
                //  versuche =  // Vergleichen, ob die gewählte Zahl mit der zufälligen übereinstimmt und mitzählen, wie viele Versuche man gebraucht hat
                // versuche++;
                GameWon(randomNumber, versuche); // Bei richtiger Antwort, Ausgabe der Gewinnnachricht und der Versuche wie oft man gebraucht hat
                again = GoAgain();
            }
            while (again);         
            
        }
        private static int GenerateNumber()
        {
            int randomNumber;
            Random rnd = new Random();
            randomNumber = rnd.Next(1, 11);
            return randomNumber;
        }
        private static int NumberInput()
        { 
            string number;
            Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 10 ein!");
            number = Console.ReadLine() ?? "";
            return InputValidation(number);
            
        }
        private static int InputValidation(string inputNumber)
        {
            int validatedNumber;
            
            if (!int.TryParse(inputNumber, out validatedNumber))
            {
                Console.Clear();    
                Console.WriteLine("{0} ist keine Zahl!", inputNumber);
                return -1; 
            }
            else
            {
                return validatedNumber;
            }
        }
        private static bool InvalidNumberRange(int validatedNumber)
        {
            if (validatedNumber <= 0 || validatedNumber > 10)
            {
                Console.Clear();
                Console.Write("Bitte nur Zahlen zwischen 1 und 10 benutzen!\n");
                return false;
            }
            else
            {
                return true; 
            }
        }
        private static bool NumberVerification(int inputNumber,int randomNumber)
        {
           
            while(true)
            {

                if (randomNumber > inputNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"Die Zahl ist größer als {inputNumber}!");
                    return true;
                }
                else if (randomNumber < inputNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"Die Zahl ist kleiner als {inputNumber}!");
                    return true;
                }
                else
                {
                    Console.Clear();
                    return false;
                }
                

            } 
            
        }

        private static void GameWon(int randomNumber, int versuche)
        {
            Console.Clear();
            Console.WriteLine($"Richtig! Die Zahl war {randomNumber} und du hast {versuche} Versuche gebraucht!\n");           
        
        }
        
        private static bool GoAgain()
        {
            while(true)
           {
            Console.WriteLine("Möchtest du noch einmal spielen? \n (Y)es oder (N)o?");
             string AgainInput = Console.ReadLine() ?? "";
                if (AgainInput == "y" || AgainInput == "Y")
                {
                    Console.Clear();
                    return true;
                }
                else if (AgainInput == "n" || AgainInput == "N")
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bitte nur mit Y oder N Antworten!");
                }
            }

        }    
    }
}
