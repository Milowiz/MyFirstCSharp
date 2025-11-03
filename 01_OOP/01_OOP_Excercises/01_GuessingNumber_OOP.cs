using System.Diagnostics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _01_OOP
{
    public class _01_GuessingNumber_OOP
    {
        public static void Run()
        {

            
            GameState gameState = new GameState();
            gameState.GameStart();

            
        }
    }


    
    public class NumberHandler
    {
        public int ValidatedNumber { get; private set; }
        public bool VerifiedNumber { get; set; }
        public int InputNumber { get; set; }
        public bool IsNumberInRange { get; set; }
        public int GeneratedNumber{ get; set; }
        public static int ValidatedInput(string inputNumber)
        {

            if (!int.TryParse(inputNumber, out int validatedNumber))
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
        internal static bool NumberVerification(int inputNumber, int randomNumber)
        {

            while (true)
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
        internal static int NumberInput()
        {

            Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 10 ein!");
            string number = Console.ReadLine() ?? "";
            return NumberHandler.ValidatedInput(number);

        }
        internal static bool InvalidNumberRange(int validatedNumber)
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
        internal static int GenerateNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 11);
            return randomNumber;
        }
        public NumberHandler(string inputNumber)
        {
            InputNumber = NumberInput();
            ValidatedNumber = ValidatedInput(inputNumber);
        }
        public NumberHandler(int inputNumber, int randomNumber)
        {
            VerifiedNumber = NumberVerification(inputNumber, randomNumber);
        }
        public NumberHandler(int validatedNumber)
        {
            IsNumberInRange = InvalidNumberRange(validatedNumber);
        }

        public NumberHandler()
        {
            GeneratedNumber = GenerateNumber();
        }

    }
    public class GameState
    {
        public static void GameWon(int randomNumber, int versuche)
        {
            Console.Clear();
            System.Console.WriteLine($"Richtig! Die Zahl war {randomNumber} und du hast {versuche} Versuche gebraucht!\n");

        }
        public static bool GoAgain()
        {
            while (true)
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
         public void GameStart()
            {
                NumberHandler inputHandler = new NumberHandler();
                bool again;
                bool isVerified;
                Console.Clear();
                do
                {
                    int versuche = 0;
                    int inputNumber;
                    int randomNumber = NumberHandler.GenerateNumber();
                    

                    do
                    {
                        inputNumber = NumberHandler.NumberInput();
                        isVerified = NumberHandler.NumberVerification(inputNumber, randomNumber);
                        if (NumberHandler.InvalidNumberRange(inputNumber) == true)
                        {
                            versuche++;
                        }
                    }
                    while (isVerified);

                    GameWon(randomNumber, versuche);
                    again = GoAgain();
                }
                while (again);

        // public GameState(int randomNumber, int versuche)
        // {
        //     GameWon(randomNumber, versuche);
        // }
    }
        public class Game
        {


           
            }
        
        
    }    
}


