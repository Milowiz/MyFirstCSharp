namespace _02_OOP
{
    /* ############################################################################################

      Kapselung (Encapsulation) in C#

      Kapselung ist ein grundlegendes Prinzip der objektorientierten Programmierung, das darauf abzielt,
      die Daten und Methoden einer Klasse zu schützen und den Zugriff darauf zu kontrollieren.

      Hauptaspekte der Kapselung:
          - Zugriffskontrollmodifikatoren: In C# gibt es verschiedene Modifikatoren wie public, private,
            protected und internal, die den Zugriff auf Klassenmitglieder (Attribute und Methoden) steuern.
          - Datenversteckung: Durch die Verwendung von privaten Attributen und öffentlichen Methoden
            (Getter und Setter) können Sie den direkten Zugriff auf die Daten verhindern und deren
            Integrität sicherstellen.
          - Schnittstellen: Kapselung ermöglicht es, eine klare Schnittstelle für die Interaktion mit
            einer Klasse bereitzustellen, während die interne Implementierung verborgen bleibt.
          - Wartbarkeit: Durch Kapselung wird der Code modularer und leichter wartbar, da Änderungen
            an der internen Implementierung einer Klasse keine Auswirkungen auf den externen Code haben,
            der diese Klasse verwendet.

      Vorteile der Kapselung:
          - Schutz der Datenintegrität durch kontrollierten Zugriff.
          - Reduzierung von Abhängigkeiten zwischen Klassen.
          - Verbesserung der Lesbarkeit und Wartbarkeit des Codes.
          - Erleichterung der Fehlerbehebung und Erweiterung des Codes.

      Access modifiers in C#:
          - public: Zugriff von überall.
          - private: Zugriff nur innerhalb der Klasse.
          - protected: Zugriff innerhalb der Klasse und abgeleiteten Klassen.
          - internal: Zugriff innerhalb desselben Assemblies.
          - protected internal: Zugriff innerhalb desselben Assemblies und von abgeleiteten Klassen.

      Getter und Setter:
          - Methoden, die den Zugriff auf private Attribute ermöglichen.
          - Getter: Methode zum Abrufen des Werts eines Attributs.
          - Setter: Methode zum Festlegen des Werts eines Attributs.

      ############################################################################################ */

    internal class BankAccount
    {
        // Private Attribute der Klasse BankAccount
        private string accountNumber;
        private decimal balance;

        // Konstruktor der Klasse BankAccount
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            this.accountNumber = accountNumber;
            balance = initialBalance;
        }

        // Öffentliche Methode zum Einzahlen von Geld
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"{amount} wurde eingezahlt.");
            }
            else
            {
                Console.WriteLine("Einzahlungsbetrag muss positiv sein.");
            }
        }

        // Öffentliche Methode zum Abheben von Geld
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"{amount} wurde abgehoben.");
                return true;
            }
            else
            {
                Console.WriteLine("Abhebungsbetrag ist ungültig oder unzureichender Kontostand.");
                return false;
            }
        }

        // Öffentliche Methode zum Abrufen des Kontostands
        public decimal GetBalance()
        {
            return balance;
        }
    }

    class _03_Encapsulation
    {
        public static void Run()
        {
            // Erstellen eines Objekts der Klasse BankAccount
            BankAccount account = new BankAccount("123456", 1000.0m);

            // Zugriff auf öffentliche Methode zum Einzahlen von Geld
            account.Deposit(500.0m);
            Console.WriteLine($"Kontostand nach Einzahlung: {account.GetBalance()}");

            // Versuch, direkt auf das private Attribut zuzugreifen (wird nicht funktionieren)
            // account.balance += 200.0m; // Fehler: 'BankAccount.balance' ist nicht zugänglich

            // Zugriff auf öffentliche Methode zum Abheben von Geld
            bool success = account.Withdraw(300.0m);
            if (success)
            {
                Console.WriteLine($"Kontostand nach Abhebung: {account.GetBalance()}");
            }
            else
            {
                Console.WriteLine("Abhebung fehlgeschlagen: unzureichender Kontostand.");
            }
        }
    }
}