using System.Net.Mime;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.IO;

namespace _00_Exercises
{
    public class _02_Hangman
    {
        public static void Run()
        {
            
            bool inputIsValid;
            int lives = 6;
            string word = GetRandomWordFromFile();
            int wordLength = word.Length;
            string underscoreWord = TurnWordInUnderscores(wordLength);
            do
            {
                Console.WriteLine("Welcher Buchstabe kommt in diesem Wort vor?");
                string input = Console.ReadLine() ?? "";
                inputIsValid = InputHandle(input);
                if (inputIsValid == true)
                {
                    Console.Write("Bitte nur einzelne Buchstaben benutzen!");
                }

            } while (inputIsValid == false); 

            Console.WriteLine($"{word}; {wordLength}; {underscoreWord}");        
        }
        private static string GetRandomWordFromFile()
        {
            var lines = File.ReadAllLines("/home/thomas/development/myfirstC#/00_Exercises/words.txt");
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            var line = lines[randomLineNumber];
            return line;
        }
        private static string TurnWordInUnderscores(int wordLength)
        {
            string underscoreWord = "";
            for (int i = 0; i <= wordLength; i++)
            {
                underscoreWord += "_";
            }
            return underscoreWord;
        }


        private static bool InputHandle(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                return false;

            }
            return true;
        }   
    }
}