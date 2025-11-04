namespace _02_OOP._00_Exercises
{
    public class _01_Hangman
    {
        public static void Run()
        {

            HangmanGame game = new HangmanGame();
            game.StartGame();
        }

        /// <summary>
        /// Represents the hangman game with all states and handling
        /// functionalities in order to play this game
        /// </summary>
        public class HangmanGame
        {
            private readonly string[] HANGMAN_STATES = {
            "",
            "============",
            "     |\n     |\n     |\n     |\n     |\n     |\n============",
            "  +--+\n     |\n     |\n     |\n     |\n     |\n============",
            "  +--+\n  |  |\n     |\n     |\n     |\n     |\n============",
            "  +--+\n  |  |\n  O  |\n     |\n     |\n     |\n============",
            "  +--+\n  |  |\n  O  |\n  |  |\n     |\n     |\n============",
            "  +--+\n  |  |\n  O  |\n /|\\ |\n / \\ |\n     |\n============"
        };

            private Player Player { get; set; }
            private string WordToGuess { get; set; }
            private char[] WordState { get; set; }

            /// <summary>
            /// Standard constructor for initiliazing the game
            /// </summary>
            public HangmanGame()
            {
                Player = new Player();
                WordToGuess = ChooseRandomWordFromFile("./Files/Hangman-Wordlist.txt").ToLower();
                CreateWordState();
            }

            /// <summary>
            /// Starts the hangman game, managing the game loop and player interactions.
            /// </summary>
            public void StartGame()
            {
                while (Player.Lives > 0 && WordState.Contains('_'))
                {
                    DisplayGameState();
                    char guessedLetter = Player.GetGuessedChar();
                    if (WordToGuess.Contains(guessedLetter))
                    {
                        UpdateWordState(guessedLetter);
                    }
                    else
                    {
                        Player.DecreaseLife();
                        Console.WriteLine("Wrong guess! Lives left: " + Player.Lives);
                    }
                }

                DisplayGameState();
                if (Player.Lives == 0)
                {
                    Console.WriteLine("Game Over! The word was: " + WordToGuess);
                }
                else
                {
                    Console.WriteLine("Congratulations! You've guessed the word: " + WordToGuess);
                }
            }

            /// <summary>
            /// Updates the word state by replacing underscores with the actual letter that has been guessed
            /// </summary>
            /// <param name="guessedLetter">The guessed letter, to replace in wordState</param>
            private void UpdateWordState(char guessedLetter)
            {
                for (int i = 0; i < WordState.Length; i++)
                {
                    if (WordToGuess[i] == guessedLetter)
                    {
                        WordState[i] = guessedLetter;
                    }
                }
            }

            /// <summary>
            /// Displays the current state of the hangman and the word being guessed.
            /// </summary>
            private void DisplayGameState()
            {
                Console.Clear();
                Console.WriteLine(HANGMAN_STATES[7 - Player.Lives]);
                Console.WriteLine("Word: " + new string(WordState));
            }

            /// <summary>
            /// Loads a list of words from a specified file and selects one at random.
            /// </summary>
            /// <param name="filePath">The path to the file containing the word list.</param>
            /// <returns>A randomly selected word from the list.</returns>
            private string ChooseRandomWordFromFile()
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt"); // Da daheim anderer Path in WSL in .csproj damit immer garanteiren, dass es im gleichen Verzeichnis ist
                var lines = File.ReadAllLines(filePath);
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length);
                var line = lines[randomLineNumber];
                return line;
            }

            /// <summary>
            /// Creates the word state containing underscores based on the word to guess
            /// </summary>
            private void CreateWordState()
            {
                WordState = new char[WordToGuess.Length];
                for (int i = 0; i < WordToGuess.Length; i++)
                {
                    WordState[i] = '_';
                }
            }

        }



        public class Player
        {
            public int Lives { get; private set; }

            /// <summary>
            /// Standard constructor for initializing the Player object
            /// </summary>
            public Player()
            {
                Lives = 7;
            }

            /// <summary>
            /// Prompts the player to enter a single letter as their guess.
            /// Validates the input to ensure it is a single alphabetic character.
            /// </summary>
            /// <returns>The guessed character as a string.</returns>
            public char GetGuessedChar()
            {
                while (true)
                {
                    Console.Write("Enter your guess (a single letter): ");
                    string input = Console.ReadLine().ToLower() ?? string.Empty.ToLower();

                    if (input.Length != 1 || !char.IsLetter(input[0]))
                    {
                        ConsoleHelper.ClearConsoleLines(1);
                        Console.Write("Invalid input. Please enter a single letter.");
                        continue;
                    }

                    return input[0];
                }
            }

            /// <summary>
            /// Decreases the player's lives by one.
            /// </summary>
            public void DecreaseLife()
            {
                if (Lives > 0)
                {
                    Lives--;
                }
            }
        }

        public static class ConsoleHelper
        {
            /// <summary>
            /// Clears the specified number of lines from the console.
            /// </summary>
            /// <param name="numberOfLines">The number of lines to clear above the current cursor position.</param>
            public static void ClearConsoleLines(int numberOfLines)
            {
                int currentCursorTop = Console.CursorTop - numberOfLines;
                for (int i = 0; i < numberOfLines; i++)
                {
                    Console.SetCursorPosition(0, currentCursorTop + i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }

                Console.SetCursorPosition(0, currentCursorTop);
            }
        }
    }
}