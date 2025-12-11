using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace _01_Kontosystem
{
    public class AccountAgent
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Bearbeitungsgebühr pro Abhebung in Euro: ");
            float fee = ReadPositiveFloat();
            System.Console.WriteLine("Name des Users: ");
            string name = Console.ReadLine() ?? "";
            User user = new User(name);
            user.OpenAccount(fee);
            while (true)
            {
                Menu(user);
            }
        }

        public static void Menu(User user)
        {
            if (user.Konto is null)
            {
                System.Console.WriteLine("Kein Konto vorhanden. Bitte Konto eröffnen");
                Thread.Sleep(1500);
                return;
            }
            if (!ReferenceEquals(user.Konto.Owner, user))
            {
                System.Console.WriteLine("Sicherheitsfehler: Konto ist nicht mit dem aktuellen User verknüpft!");
                Thread.Sleep(1500);
                return;
            }
            Console.Clear();
            Console.WriteLine($"------- Konto von: {user.Name} --------");
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("[1] Accountbalance anzeigen");
            Console.WriteLine("[2] Geld einzahlen");
            Console.WriteLine("[3] Geld abheben");
            Console.WriteLine("[4] Verlassen");

            string userInput = Console.ReadLine() ?? "";
            int.TryParse(userInput, out int vUserInput);
            switch (vUserInput)
            {
                case 1:
                    System.Console.WriteLine($"Kontostand: {user.Konto.Balance:0.00} €");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    System.Console.WriteLine("Einzahlungbetrag in Euro: ");
                    float deposit = ReadPositiveFloat();
                    try
                    {
                        user.Konto.Deposit(deposit);
                        System.Console.WriteLine($"Neuer Kontostand: {user.Konto.Balance:0.00}");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    Thread.Sleep(2000);
                    break;
                case 3:
                    System.Console.WriteLine("Abhebungsbetrag in Euro: ");
                    float withdraw = ReadPositiveFloat();
                    if (user.Konto.TryWithdraw(withdraw, out string error))
                    {
                        System.Console.WriteLine($"Neuer Kontostand: {user.Konto.Balance:0.00}");
                    }
                    else
                    {
                        System.Console.WriteLine(error);
                    }
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($"Tschüss {user.Name} bis zum nächsten Mal!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe bitte versuche es nochmal!");
                    break;
            }
        }
        private static float ReadPositiveFloat()
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                if (float.TryParse(input, out float value) && value > 0)
                {
                    return value;
                }
                System.Console.WriteLine("Bitte eine gültige Zahl größer 0 eingeben: ");
            }
        }
    }
}