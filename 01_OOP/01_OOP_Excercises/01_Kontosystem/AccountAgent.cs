using System.Collections;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace _01_Kontosystem
{
    public class AccountAgent
    {
        public static void Run()
        {
            Konto konto = new Konto();
            konto.SetFee();
            konto.CreateUser();
            while (true)
            {
                Menu(konto);
            }
        }

        public static void Menu(Konto konto)
        {
            Console.Clear();
            Console.WriteLine($"------- Konto von: {konto.GetUserName()} --------");
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("[1] Accountbalance anzeigen");
            Console.WriteLine("[2] Geld einzahlen");
            Console.WriteLine("[3] Geld abheben");
            Console.WriteLine("[4] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:
                    konto.ShowBalance();
                    Thread.Sleep(2000);
                    break;
                case 2:
                    konto.Deposit();
                    Thread.Sleep(2000);
                    break;
                case 3:
                    konto.Withdraw();
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($"Tschüss {konto.GetUserName()} bis zum nächsten Mal!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe bitte versuche es nochmal!");
                    break;
            }
        }
    }
}