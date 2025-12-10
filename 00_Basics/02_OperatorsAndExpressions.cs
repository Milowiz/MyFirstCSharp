using System.Globalization;
using System.Runtime.InteropServices;

namespace _00_Basics
{

    public class _04_ArraysAndLists
    {
        public static void Run()
        {
            // ### Liste ###
            List<int> numbers = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                numbers.Add(i);
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
                Thread.Sleep(500);
            }
            for (int i = 0; i < 6; i++)
            {
                numbers.Remove(i);
            }

            // ### Array ###

            char[] arrayChars = new char[7];

            for (int i = 0; i < 7; i++)
            {
                arrayChars[i] = char.Parse(Char.ConvertFromUtf32(i + 65));
            }

            foreach (char c in arrayChars)
            {
                Console.WriteLine($"Array -> {c}");
            }
        }
        public static void Aufgabe()
        {
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4 };
            char[] chars = { 'A', 'B', 'C', 'D', 'E' };

            // ### Auf drittes Element zugreifen ###
            Console.WriteLine($"L[2] -> {numbers.ElementAt(2)}"); // numbers[2]
            Console.WriteLine($"A[2] -> {chars[2]}");

            // ### Sechstes Element hinzufügen ###
            numbers.Add(5);

            // Sechstes Element für das Array
            char[] tempChars = chars; // Erstellen eines temporären Array
            chars = new char[6];
            for (int i = 0; i < 5; i++)
            {
                chars[i] = tempChars[i];
            }
            chars[5] = 'F';

            // ### Zweites Element entfernen ###
            numbers.RemoveAt(1);

            tempChars = chars; // Erstellen eines temporären Array
            chars = new char[5];
            // Kopieren der Elemente außer dem zweiten
            for (int i = 0; i < 1; i++)
            {
                chars[i] = tempChars[i];
            }
            // Überspringen des zweiten Elements
            for (int i = 2; i < 6; i++)
            {
                chars[i - 1] = tempChars[i];
            }

            // ### Alle Elemente ausgeben ###
            foreach (int number in numbers)
            {
                Console.WriteLine($"L -> {number}");
            }

            foreach (char c in chars)
            {
                Console.WriteLine($"A -> {c}");
            }
        }
    }
    
}