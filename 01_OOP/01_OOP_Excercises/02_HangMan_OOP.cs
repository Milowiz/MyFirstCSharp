using System.Net.Mime;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Globalization;
using System.Dynamic;

namespace _01_OOP
{
    public class _02_Hangman_OOP
    {
        public static void Run()
        {
            
        }
        public class Output
        {

            public string HangmanStatus { get; set; }
            public bool RightAnswer{ get; set; }
            

            public void DisplayStatus(string hangman, int lives, string underscoreWord, List<char> alreadyUsed)
            {
                Console.Clear();
                Console.WriteLine(hangman);
                Console.WriteLine(HangmanDisplayStatus(lives));
                Console.WriteLine("Aktueller Stand: " + string.Join(" ", underscoreWord.ToUpper().ToCharArray()));
                Console.WriteLine($"Bereits verwendete Buchstaben: {string.Join(" ", alreadyUsed)}");
            }
            public string HangmanDisplayStatus(int lives)
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
            public bool DisplayRightAnswer(int lives, string underscoreWord, string randomWord)
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
            public Output()
            {

            }
            public Output(int lives)
            {
                HangmanStatus = HangmanDisplayStatus(lives);
            }
            public Output(int lives, string underscoreWord, string randomWord)
            {
                RightAnswer = DisplayRightAnswer(lives,underscoreWord,randomWord);
            }
        }
        public class Word
        {
            public string RandomWordFromFile { get; private set; }
            public string UnderscoreWord { get; set; }
            public char ValidCharInput { get; set; }
            public bool IsWrongGuess { get; set; }
            public bool IsInRandomWord;
            public string UnderScoreToWord { get; set; }

            Output output = new Output();
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
            public char GetValidCharInput(List<char> alreadyUsed, string hangman, int lives, string underscoreWord)
            {
                while (true)
                {
                    Console.Write("Welcher Buchstabe kommt in diesem Wort vor? ");
                    string input = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(input)) continue;

                    if (input.Length != 1 || !char.IsLetter(input[0]))
                    {
                        output.DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                        Console.WriteLine("\nBitte gib genau einen Buchstaben ein!");
                        Thread.Sleep(1000);
                        continue;
                    }


                    char inputChar = char.ToLower(input[0]);

                    if (alreadyUsed.Contains(inputChar))
                    {
                        output.DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                        Console.WriteLine($"{inputChar} wurde schon benutzt!");
                        Thread.Sleep(500);
                        continue;

                    }
                    alreadyUsed.Add(inputChar);
                    return inputChar;
                }
            }
            public bool HandleWrongGuess(char inputChar, ref int lives, string randomWord)
            {
                if (!IsInWord(randomWord, inputChar))
                {
                    lives--;
                    Console.Clear();
                    Console.Write("Leider falsch!");
                    Console.WriteLine(output.HangmanDisplayStatus(lives));
                    Thread.Sleep(500);
                    if (lives <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(output.HangmanDisplayStatus(lives));
                        Console.WriteLine($"\n Leider verloren! Das Wort war: {randomWord.ToUpper()}");
                        return true;
                    }
                    return false;
                }
                return false;
            }
            public bool IsInWord(string randomWord, char inputChar)
            {
                return randomWord.ToLower().Contains(inputChar);
            }
            public string TurnUnderScoreToWord(string randomWord, string underscoreWord, char inputChar)
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

            public Word(int wordLength)
            {
                UnderscoreWord = TurnWordInUnderscores(wordLength);
            }
            public Word()
            {
                RandomWordFromFile = GetRandomWordFromFile();
            }
            public Word(List<char> alreadyUsed, string hangman, int lives, string underscoreWord)
            {
                ValidCharInput = GetValidCharInput(alreadyUsed, hangman, lives, underscoreWord);
            }
            public Word(char inputChar, ref int lives, string randomWord)
            {
                IsWrongGuess = HandleWrongGuess(inputChar, ref lives, randomWord);
            }
            public Word(string randomWord, char inputChar)
            {
                IsInRandomWord = IsInWord(randomWord, inputChar);
            }
            public Word(string randomWord, string underscoreWord, char inputChar)
            {
                UnderScoreToWord = TurnUnderScoreToWord(randomWord, underscoreWord, inputChar);
            }

        }
        public class GameState
        {
            public bool PlayAgain { get; set; }
            public string RandomWord { get; set; }
            public GameState()
            {
                
            }

            public bool GoAgain()
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
            public void GameStart()

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
                Output output = new Output();
                GameState gameState = new GameState();
                string randomWord = word.GetRandomWordFromFile();
                int lives = 7;
                string underscoreWord = word.TurnWordInUnderscores(randomWord.Length);
                List<char> alreadyUsed = new List<char>();
                bool gameOver = false;
                //Console.WriteLine($"{randomWord}; {randomWord.Length}; {underscoreWord};"); // Debug
                while (!gameOver)
                {
                    output.DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);                
                    char inputChar = word.GetValidCharInput(alreadyUsed,hangman,lives,underscoreWord);

                    gameOver = word.HandleWrongGuess(inputChar, ref lives, randomWord);
                    underscoreWord = word.TurnUnderScoreToWord(randomWord, underscoreWord, inputChar);
                    if (output.DisplayRightAnswer(lives, underscoreWord, randomWord) == true) 
                    {
                        gameOver = true;
                    }
                }
                playAgain = gameState.GoAgain();
            }
            }

     
        }
    }
}
