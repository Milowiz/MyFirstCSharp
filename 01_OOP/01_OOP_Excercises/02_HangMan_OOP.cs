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
            Game game = new Game();
            game.GameStart();
        }
        public class Output
        {
            // public string HangmanStatus { get; set; }
            // public bool RightAnswer { get; set; }
            // public Output()
            // {

            // }
            // public Output(int lives)
            // {
            //     HangmanStatus = HangmanDisplayStatus(lives);
            // }
            // public Output(int lives, string underscoreWord, string randomWord)
            // {
            //     RightAnswer = DisplayRightAnswer(lives, underscoreWord, randomWord);
            // }
            public static void DisplayStatus(string hangman, int lives, string underscoreWord, List<char> alreadyUsed)
            {
                Console.Clear();
                Console.WriteLine(hangman);
                Console.WriteLine(HangmanDisplayStatus(lives));
                Console.WriteLine("Aktueller Stand: " + string.Join(" ", underscoreWord.ToUpper().ToCharArray()));
                Console.WriteLine($"Bereits verwendete Buchstaben: {string.Join(" ", alreadyUsed)}");
            }
            public static string HangmanDisplayStatus(int lives)
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
            public static bool DisplayRightAnswer(int lives, string underscoreWord, string randomWord)
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
        }
        public class Word
        {
            //public string RandomWordFromFile { get; private set; }
            // public string UnderscoreWord { get; set; }
            // public char ValidCharInput { get; set; }
            // public bool IsWrongGuess { get; set; }
            // public bool IsInRandomWord;
            // public string UnderScoreToWord { get; set; }
            //Game game = new Game();
            public static string GetRandomWordFromFile()
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt"); // Da daheim anderer Path in WSL in .csproj damit immer garanteiren, dass es im gleichen Verzeichnis ist
                var lines = File.ReadAllLines(filePath);
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length);
                var line = lines[randomLineNumber];
                return line;
            }
            public static string TurnUnderScoreToWord(string randomWord, string underscoreWord, char inputChar)
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
            public static char GetValidCharInput(List<char> alreadyUsed, string hangman, int lives, string underscoreWord)
            {
                while (true)
                {
                    Console.Write("Welcher Buchstabe kommt in diesem Wort vor? ");
                    string input = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(input)) continue;

                    if (input.Length != 1 || !char.IsLetter(input[0]))
                    {
                        Output.DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                        Console.WriteLine("\nBitte gib genau einen Buchstaben ein!");
                        Thread.Sleep(1000);
                        continue;
                    }
                    char inputChar = char.ToLower(input[0]);
                    if (alreadyUsed.Contains(inputChar))
                    {
                        Output.DisplayStatus(hangman, lives, underscoreWord, alreadyUsed);
                        Console.WriteLine($"{inputChar} wurde schon benutzt!");
                        Thread.Sleep(500);
                        continue;
                    }
                    alreadyUsed.Add(inputChar);
                    return inputChar;
                }
            }        
            public Word()
            {
               // RandomWordFromFile = GetRandomWordFromFile();
            }
            // public Word(List<char> alreadyUsed, string hangman, int lives, string underscoreWord)
            // {
            //     ValidCharInput = GetValidCharInput(alreadyUsed, hangman, lives, underscoreWord);
            // }
            // public Word(char inputChar, ref int lives, string randomWord)
            // {
            //     IsWrongGuess = HandleWrongGuess(inputChar, ref lives, randomWord);
            // }
            // public Word(string randomWord, char inputChar)
            // {
            //     IsInRandomWord = IsInWord(randomWord, inputChar);
            // }
            // public Word(string randomWord, string underscoreWord, char inputChar)
            // {
            //     UnderScoreToWord = TurnUnderScoreToWord(randomWord, underscoreWord, inputChar);
            // }

        }
        public class Game
        {
            //public bool PlayAgain { get; set; }
            public string RandomWord { get; set; }
            public string WordToUnderscore { get; set; }
            public int Lives{ get; set; }
            public Game()
            {
                RandomWord = Word.GetRandomWordFromFile();
                Lives = 7;
                WordToUnderscore = TurnWordInUnderscores(RandomWord.Length);
            }
            public bool HandleWrongGuess(char inputChar, int lives, string randomWord)
            {
                if (!IsInWord(inputChar))
                {
                    Lives = DecrementLive();
                    Console.Clear();
                    Console.Write("Leider falsch!");
                    Console.WriteLine(Output.HangmanDisplayStatus(Lives));
                    Thread.Sleep(500);
                    if (Lives <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(Output.HangmanDisplayStatus(Lives));
                        Console.WriteLine($"\n Leider verloren! Das Wort war: {randomWord.ToUpper()}");
                        return true;
                    }
                    return false;
                }
                return false;
            }
            public int DecrementLive()
            {
                Lives--;
                return Lives;
            }
            public static string TurnWordInUnderscores(int wordLength)
            {
                string underscoreWord = "";
                for (int i = 0; i < wordLength; i++)
                {
                    underscoreWord += "_";
                }
                return underscoreWord;
            }
            public bool IsInWord(char inputChar)
            {
                return RandomWord.ToLower().Contains(inputChar);
            }
            public static bool GoAgain()
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
                    //string randomWord = Word.GetRandomWordFromFile();                  
                    string underscoreWord = WordToUnderscore;
                    List<char> alreadyUsed = new List<char>();
                    bool gameOver = false;
                    //Console.WriteLine($"{randomWord}; {randomWord.Length}; {underscoreWord};"); // Debug
                    while (!gameOver)
                    {
                        Output.DisplayStatus(hangman, Lives, underscoreWord, alreadyUsed);
                        char inputChar = Word.GetValidCharInput(alreadyUsed, hangman, Lives, underscoreWord);              
                        gameOver = HandleWrongGuess(inputChar, Lives, RandomWord);
                        underscoreWord = Word.TurnUnderScoreToWord(RandomWord, underscoreWord, inputChar);
                        if (Output.DisplayRightAnswer(Lives, underscoreWord, RandomWord) == true)
                        {
                            gameOver = true;
                        }
                    }
                    playAgain = GoAgain();
                }
            }
        }
    }
}
