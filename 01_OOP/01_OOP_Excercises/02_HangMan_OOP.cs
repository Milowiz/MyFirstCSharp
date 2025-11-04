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
            do
            {
                Game game = new Game();
                game.GameStart();
            } while (Game.GoAgain());
        }
        /// <summary>
        /// Handles the displaying output methods 
        /// </summary>
        public class Output
        {
            /// <summary>
            /// Shows a summary of all values from the player in the Console
            /// </summary>
            /// <param name="hangman">Shows the Logo of hangman</param>
            /// <param name="lives">How many lives are still left for the player</param>
            /// <param name="underscoreWord">Displays the word converted to underscores with and the characters that are changed back to letters and are in the word</param>
            /// <param name="alreadyUsed">Saves the character inputs from the player to avoid multiple same inputs</param>
            public static void DisplayStatus(string hangman, int lives, string underscoreWord, List<char> alreadyUsed)
            {
                Console.Clear();
                Console.WriteLine(hangman);
                Console.WriteLine(HangmanDisplayStatus(lives));
                Console.WriteLine("Aktueller Stand: " + string.Join(" ", underscoreWord.ToUpper().ToCharArray()));
                Console.WriteLine($"Bereits verwendete Buchstaben: {string.Join(" ", alreadyUsed)}");
            }
            /// <summary>
            /// Displays different states in ASCII-Formated Hangman pictures
            /// </summary>
            /// <param name="lives">How many lives the user still has</param>
            /// <returns>Returns each different state of the switch case depending on lives</returns>
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
            /// <summary>
            /// Shows the output if the word was guessed
            /// </summary>
            /// <param name="lives">How many lives are left from the player</param>
            /// <param name="underscoreWord">Displays the word converted to underscores with and the characters that are changed back to letters and are in the word</param>
            /// <param name="randomWord">The random word chosen from the file</param>
            /// <returns>Returns true if there is no _ left in the word, otherwise false</returns>
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
        /// <summary>
        /// Handles functions that depend on the word itself
        /// </summary>
        public class Word
        {
            /// <summary>
            /// Get a random word from word.txt if word.txt exists on any path
            /// </summary>
            /// <returns>Returns a random word from word.txt</returns>
            public static string GetRandomWordFromFile()
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt"); // Da daheim anderer Path in WSL in .csproj damit immer garanteiren, dass es im gleichen Verzeichnis ist
                var lines = File.ReadAllLines(filePath);
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length);
                var line = lines[randomLineNumber];
                return line;
            }
            /// <summary>
            ///  Takes the randomWord and creates the underScoreword with the same length as randomWord
            /// </summary>
            /// <param name="randomWord">Takes the random Word from the word.txt</param>
            /// <param name="underscoreWord">Takes the already exisiting underscoreWord and changes the character back from the underscore that are correct</param>
            /// <param name="inputChar">Takes the player input</param>
            /// <returns>Gives back the updated underScoreword</returns>
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
            /// <summary>
            /// Checks if the player input is only 1 character and nothing else than a letter
            /// </summary>
            /// <param name="alreadyUsed">To check if the character was already used</param>
            /// <param name="hangman">Displays the hangman logo</param>
            /// <param name="lives">How many lives are left from the player</param>
            /// <param name="underscoreWord">Displays the word converted to underscores with and the characters that are changed back to letters and are in the word</param>
            /// <returns>Gives back the validated player input</returns>
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
            /// <summary>
            /// Empty constructor for Word to be able to create an object without errors
            /// </summary>
        }
        /// <summary>
        /// Handles the main game logic
        /// </summary>
        public class Game
        {
            private string RandomWord { get; set; }
            private string WordToUnderscore { get; set; }
            private int Lives { get; set; }
            //public static bool PlayAgain { get; set; }
            /// <summary>
            /// Sets the start paramters for the instance
            /// </summary>
            public Game()
            {
                RandomWord = Word.GetRandomWordFromFile();
                Lives = 7;
                WordToUnderscore = TurnWordInUnderscores(RandomWord.Length);
            }
            /// <summary>
            /// Handles if the guess was wrong and ends the game if the lives are 0
            /// </summary>
            /// <param name="inputChar">Takes the player input</param>
            /// <param name="lives">How many lives are left from the player</param>
            /// <param name="randomWord">Takes the random Word from the word.txt</param>
            /// <returns></returns>
            private bool HandleWrongGuess(char inputChar, int lives, string randomWord)
            {
                if (!IsInWord(inputChar))
                {
                    DecrementLive();
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
            /// <summary>
            /// Decreases the Attribute Lives by 1
            /// </summary>
            /// <returns>Returns the updated Attribute Lives</returns>
            private void DecrementLive()
            {
                Lives--;
            }
            /// <summary>
            /// Takes the length of the random word chosen and gives back the new string with the same amount of characters as underscores
            /// </summary>
            /// <param name="wordLength">The amount of characters the randomword.length has</param>
            /// <returns>Returns the same amount of underscores as the word has characters</returns>
            private static string TurnWordInUnderscores(int wordLength)
            {
                string underscoreWord = "";
                for (int i = 0; i < wordLength; i++)
                {
                    underscoreWord += "_";
                }
                return underscoreWord;
            }

            /// <summary>
            /// Checks if the randomWord contains the letter given by the player
            /// </summary>
            /// <param name="inputChar">Takes the player input</param>
            /// <returns>Returns true if there is the playerInput character in the randomWord</returns>
            private bool IsInWord(char inputChar)
            {
                return RandomWord.ToLower().Contains(inputChar);
            }

            /// <summary>
            /// Asks if the player wants to start the game again
            /// </summary>
            /// <returns>Returns true if y or Y is pressed py the player and ends by n or N and has a check that only valid answers are possible</returns>
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

            /// <summary>
            /// The main gameloop which starts and handles the game
            /// </summary>
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

                Console.Clear();
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
            }
        }
    }
}
