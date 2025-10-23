using System.Net.Mime;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Collections.Immutable;

namespace _00_Exercises
{
    public class _02_Hangman
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

            bool inputIsValid;
            int lives = 6;
            string input;
            string randomWord = GetRandomWordFromFile();
            int wordLength = randomWord.Length;
            string underscoreWord = TurnWordInUnderscores(wordLength);
            Console.Clear();
            Console.WriteLine(hangman);
            bool gameOver = false;
            List<char> alreadyUsed = new List<char>();
            Console.WriteLine($"{randomWord}; {wordLength}; {underscoreWord};");
            do
            {
                do
                {
                    Console.WriteLine("Welcher Buchstabe kommt in diesem Wort vor?");
                    input = Console.ReadLine() ?? "";
                    inputIsValid = InputHandle(input);
                    CheckForDuplicateInput(input, alreadyUsed);
                    underscoreWord = TurnUnderScoreToWord(randomWord, underscoreWord, input);
                    Console.WriteLine("{0}", string.Join(" ", underscoreWord.ToUpper()));
                    Console.WriteLine($"{underscoreWord}");
                    
                    if (inputIsValid == false)
                    {
                        Console.Write("Bitte nur einzelne Buchstaben benutzen!\n");
                    }
                    

                } while (inputIsValid == false);
                bool isInWord = IsInWord(randomWord, input);
                if (isInWord == false)
                {
                    if (lives == 0)
                    {
                        gameOver = true;
                    }
                    else
                    {
                        lives--;
                        Console.WriteLine(HangmanDisplayStatus(lives));
                    }
                    Console.WriteLine(HangmanDisplayStatus(lives));
                }

                Console.WriteLine($"{randomWord}; {wordLength}; {underscoreWord};IsInWord{isInWord}");
            }
            while (gameOver == false);
            Console.WriteLine($"Leider verloren!\n{HangmanDisplayStatus(lives)}");
        }
        private static string GetRandomWordFromFile()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt"); // Da daheim anderer Path in WSL in .csproj damit immer garanteiren, dass es im gleichen Verzeichnis ist
            var lines = File.ReadAllLines(filePath);
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            var line = lines[randomLineNumber];
            return line;
        }
        private static string TurnWordInUnderscores(int wordLength)
        {
            string underscoreWord = "";
            for (int i = 0; i < wordLength; i++)
            {
                underscoreWord += "_";
            }
            return underscoreWord;
        }


        private static bool InputHandle(string input)
        {
            if (input.Length >= 2 || input.Length == 0 || input == "")
            {
                return false;
            }

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    return true;

            }
            return false;
        }

        private static bool IsInWord(string randomWord, string input)
        {
            char character = char.Parse(input);

            foreach (char c in randomWord.ToLower())
            {
                if (character == c)
                {
                    return true;
                }

            }
            return false;
        }
        private static string TurnUnderScoreToWord(string randomWord, string underscoreWord, string input)
        {
            char[] underscoreChar = underscoreWord.ToCharArray();
            char inputChar = char.ToLower(input[0]);
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (char.ToLower(randomWord[i]) == inputChar)
                {
                    underscoreChar[i] = inputChar;
                }
            }
            return new string(underscoreChar);
        }
    private static List<char> CheckForDuplicateInput(string input, List<char> alreadyUsed)
            {
            char inputChar = char.ToLower(input[0]);
            
                if (alreadyUsed.Contains(inputChar))
                {

                Console.WriteLine($"{inputChar} wurde schon benutzt! Deine Versuche bisher waren: {string.Join(" ", alreadyUsed)}");
                
                }
                else
                {
                alreadyUsed.Add(inputChar);
                Console.WriteLine($"{inputChar} wurde hinzugefügt");
                
                }
                return alreadyUsed;
            }
            
        
    private static string HangmanDisplayStatus(int lives)
        {
            
            switch (lives)
            {
                case 5:
                    return " +---+\n |   |\n     |\n     |\n     |\n     |\n=======";

                case 4:
                    return " +---+\n |   |\n O   |\n     |\n     |\n     |\n=======";

                case 3:
                    return " +---+\n |   |\n O   |\n |   |\n     |\n     |\n=======";

                case 2:
                    return " +---+\n |   |\n O   |\n/|   |\n     |\n     |\n=======";
                case 1:
                    return " +---+\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=======";

                case 0:
                    return " +---+\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n=======";   
            }
            return "false";
        }
    }
}

// for(char c in randomWord)
// if(c == input)
// poistion[] = []


// for(char c in underScore)
// underScoreWord[position] = input