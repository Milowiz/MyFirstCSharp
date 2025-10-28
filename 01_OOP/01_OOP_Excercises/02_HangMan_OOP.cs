using System.Net.Mime;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Globalization;

namespace _01_OOP
{
    public class _02_Hangman_OOP
    {
        public static void Run()
        {
            

            string hangman = " _\n" +
                            "| |\n" +
                            "| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  \n" +
                            "| '_ \\ / _` | '_ \\ / _` | '_ ` _ \\ / _` | '_ \\ \n" +
                            "| | | | (_| | | | | (_| | | | | | | (_| | | | |\n" +
                            "|_| |_|\\__,_|_| |_|\\__, |_| |_| |_|\\__,_|_| |_|\n" +
                            "                    __/ |\n" +
                            "                   |___/\n";
            bool playAgain = true;
             
            while (playAgain)
            {
                Console.Clear();
                Word word = new Word();
                string randomWord = word.GetRandomWordFromFile();
                int lives = 7;
                string underscoreWord = word.TurnWordInUnderscores(randomWord.Length);
                List<char> alreadyUsed = new List<char>();
                bool gameOver = false;
                //Console.WriteLine($"{randomWord}; {randomWord.Length}; {underscoreWord};"); // Debug
                while (!gameOver)
                {
                    DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);                
                    char inputChar = GetValidCharInput(alreadyUsed,hangman,lives,underscoreWord);

                    gameOver = HandleWrongGuess(inputChar, ref lives, randomWord);
                    

                    underscoreWord = TurnUnderScoreToWord(randomWord, underscoreWord, inputChar);
                    if (DisplayRightAnswer(lives, underscoreWord, randomWord) == true) 
                    {
                        gameOver = true;
                    }
                }
                playAgain = GoAgain();
            }
        }

        private static bool DisplayRightAnswer(int lives, string underscoreWord, string randomWord)
        {
                
                if (!underscoreWord.Contains('_'))
                {
                    Console.Clear();
                    Console.WriteLine(HangmanDisplayStatus(lives));
                    Console.WriteLine($"\nGlückwunsch! Das vollständige Wort lautet: {randomWord.ToUpper()}");
                    return true;
                }
                return false; 
        }
        private static bool HandleWrongGuess(char inputChar,ref int lives, string randomWord)
        {
            if (!IsInWord(randomWord, inputChar))
            {
                lives--;
                Console.Clear();
                Console.Write("Leider falsch!");
                Console.WriteLine(HangmanDisplayStatus(lives));
                Thread.Sleep(500);
                if (lives <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(HangmanDisplayStatus(lives));
                    Console.WriteLine($"\n Leider verloren! Das Wort war: {randomWord.ToUpper()}");
                    return true;
                }
                return false;
            }
            return false;
        }
        private static bool IsInWord(string randomWord, char inputChar)
        {
            return randomWord.ToLower().Contains(inputChar);
        }
        private static string TurnUnderScoreToWord(string randomWord, string underscoreWord, char inputChar)
        {
            var underscoreChar = underscoreWord.ToCharArray();
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (char.ToLower(randomWord[i]) == inputChar)
                {
                    underscoreChar[i] = randomWord[i]; 
                }
            }
            return new string(underscoreChar);
        }
        private static bool GoAgain()
        {
            while (true)
            {
                Console.WriteLine("Möchtest du noch einmal spielen? \n (Y)es oder (N)o?");
                string againInput = Console.ReadLine() ?? "";
                if (againInput == "y" || againInput == "Y")
                {
                    Console.Clear();
                    return true;
                }
                else if (againInput == "n" || againInput == "N")
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
        private static char GetValidCharInput(List<char> alreadyUsed,string hangman,int lives, string underscoreWord)
        {
            while (true)
            {
                Console.Write("Welcher Buchstabe kommt in diesem Wort vor? ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input)) continue;
                
                if (input.Length != 1 || !char.IsLetter(input[0]))
                {
                    DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                    Console.WriteLine("\nBitte gib genau einen Buchstaben ein!");
                    Thread.Sleep(1000);
                    continue;
                }


                char inputChar = char.ToLower(input[0]);

                if (alreadyUsed.Contains(inputChar))
                {
                    DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                    Console.WriteLine($"{inputChar} wurde schon benutzt!");
                    Thread.Sleep(500);
                    continue;

                }
                alreadyUsed.Add(inputChar);
                return inputChar;
            }
        }
        private static void DisplayStatus(string hangman, int lives, string underscoreWord, List<char>alreadyUsed)
        {
                    Console.Clear();
                    Console.WriteLine(hangman);
                    Console.WriteLine(HangmanDisplayStatus(lives));
                    Console.WriteLine("Aktueller Stand: " + string.Join(" ", underscoreWord.ToUpper().ToCharArray()));
                    Console.WriteLine($"Bereits verwendete Buchstaben: {string.Join(" ", alreadyUsed)}");
        }
        private static string HangmanDisplayStatus(int lives)
        {

            switch (lives)
            {
                case 6:
                    return " \n +---+\n |   |\n     |\n     |\n     |\n     |\n=======";

                case 5:
                    return " \n +---+\n |   |\n O   |\n     |\n     |\n     |\n=======";

                case 4:
                    return " \n +---+\n |   |\n O   |\n |   |\n     |\n     |\n=======";

                case 3:
                    return " \n +---+\n |   |\n O   |\n/|   |\n     |\n     |\n=======";
                case 2:
                    return " \n +---+\n |   |\n O   |\n/|\\  |\n     |\n     |\n=======";
                case 1:
                    return " \n +---+\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=======";

                case 0:
                    return " \n +---+\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n=======";
                default:
                    return "";
            }
        }
        public class Word
        {
            public string RandomWordFromFile { get; private set; }
            public string UnderscoreWord{ get; set; }

            
            public string GetRandomWordFromFile()
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt"); // Da daheim anderer Path in WSL in .csproj damit immer garanteiren, dass es im gleichen Verzeichnis ist
                var lines = File.ReadAllLines(filePath);
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length);
                var line = lines[randomLineNumber];
                return line;
            }
            public string TurnWordInUnderscores(int wordLength)
            {
                string underscoreWord = "";
                for (int i = 0; i < wordLength; i++)
                {
                    underscoreWord += "_";
                }
                return underscoreWord;
            }
            public Word(int wordLength)
            {
                UnderscoreWord = TurnWordInUnderscores(wordLength);
            }
            public Word()
            {
                RandomWordFromFile = GetRandomWordFromFile();
            }
            
        }
    }
}
