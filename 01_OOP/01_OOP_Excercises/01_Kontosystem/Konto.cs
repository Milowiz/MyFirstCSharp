using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace _01_Kontosystem
{
    public class Konto
    {
        private float Balance { get; set; }
        private float Fee {get; set;}

        public Konto()
        {
            
        }


        public void ShowBalance()
        {
            Console.WriteLine($"{User} auf deinem Konto stehen dir zur Zeit {Balance}€ zur Verfügung!");
        }
        public void Deposit()
        {
            System.Console.WriteLine("Wie viel möchtest du einzahlen?");
            string input = Console.ReadLine() ?? "";
            if ((!float.TryParse(input, out float vInput)) || vInput <= 0)
            {
                System.Console.WriteLine("Bitte nur einen gültigen Betrag über 0 eingeben !");
            }
            else
            {
                Balance += vInput;
                System.Console.WriteLine($"Dein neuer Kontostand beträgt: {Balance}€");
            }

        }

        public void Withdraw()
        {
            Console.WriteLine("Wie viel Geld möchtest du abheben?");
            string input = Console.ReadLine() ?? "";
            if ((!float.TryParse(input, out float vInput)) || vInput <= 0)
            {
                Console.WriteLine("Bitte nur einen gültigen Betrag eingeben!");
                return;
            }
            else if ((Balance - vInput - Fee) <= 0)
            {
                Console.WriteLine("Du hast leider zu wenig Geld auf deinem Konto!");
                return;
            }
            else
            {
                float res = Balance - vInput - Fee;
                Balance = res;
                System.Console.WriteLine($"Dein neuer Kontostand beträgt: {Balance}€");
            }
        }


        public User CreateUser()
        {
            Console.WriteLine("User Erstellen: \n");
            string userInput = Console.ReadLine() ?? "";
            User user = new User($"{userInput}");
            Console.WriteLine($"Der User mit dem Namen {user} wurde erstellt!");
            return user;
        }
        public string GetUserName(User user)
        {
            return user.Name;
        }
        public void SetFee()
        {
            System.Console.WriteLine("Wie hoch soll die Bearbeitungsgebühr sein?");
            string userInput = Console.ReadLine() ?? "";
            if(float.TryParse(userInput,out float newFee))
            {
                Fee = newFee;
            }
            else
            {
                System.Console.WriteLine("Keine gültige Eingabe!");
                Environment.Exit(1);
            }

            
        }


        // public override string ToString()
        // {
        //     return $"Hallo {User}, du hast aktuell {Balance}€ zur Verfügung!";
        // }


    }
}