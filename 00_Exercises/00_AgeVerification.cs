using System.ComponentModel.DataAnnotations;
using System.Net;

namespace _00_Exercises
{
    public class _00_AgeVerification
    {
        public static void Run()
        {
            string name = HandleNameInput();
            ushort age = HandleAgeInput();
            bool verified = AgeVerification(age);
            AgeOutput(name, age, verified);
            NameLength(name);
            NameVertical(name);
        }

        private static string HandleNameInput()
        {
            string name;
            do
            {
                Console.WriteLine("Geben Sie Ihren Vornamen ein!");
                name = Console.ReadLine() ?? null;
                if (!(name == "") && name.All(c => char.IsLetter(c))) //Wenn Name ein Leererstring oder nur aus Buchstaben besteht23
                {
                    return name;
                }
                Console.WriteLine("Ungültige Eingabe!");
            }
            while (true);

        }




        private static ushort HandleAgeInput()
        {
            string line;
            ushort age;
            do
            {
                Console.WriteLine("Geben Sie Ihr Alter ein!");
                line = Console.ReadLine();  //Alternative 
                // if (!int.TryParse(line, out age))
                // {
                //     Console.WriteLine("{0} ist keine Zahl!", line);

                // }
                // else
                // {
                //     return age;
                // }
                try
                {
                    age = ushort.Parse(Console.ReadLine());
                    return age;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Keine gültige Angabe!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Keine gültige Angabe!");
                }

                //if ((age ) && age.All(c => char.IsNumber(c)))
            } while (true);

        }

        private static bool AgeVerification(ushort p_age)
        {
            return p_age >= 18; //Einzeiler vom auskommentiertem, da age >= 18 = true ist
            // if (age >= 18) 
            // {
            //     return true;
            // }

            // return false;

        }

        private static void AgeOutput(string name, ushort age, bool verified)
        {
            if (verified == true)
            {
                Console.WriteLine($"Hallo, {name} du bist {age} und damit volljährig!");
            }
            else
            {
                Console.WriteLine($"Hallo, {name} du bist {age} und damit nicht volljährig!");
            }
        }

        private static void NameLength(string name)
        {
            Console.WriteLine($"Dein Name ist {name.Length} lang!");
        }

        private static void NameVertical(string name)
        {
            foreach (char c in name)
            {
                System.Console.WriteLine(c);
            }
            
        }
    }
}