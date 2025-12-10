namespace _02_OOP
{
    /*##################################################################################

    Statische Klassen und Methoden in C#
    Statische Klassen und Methoden sind solche, die ohne die Notwendigkeit einer Instanz der Klasse aufgerufen werden können.
    Statische Klassen werden mit dem Schlüsselwort 'static' deklariert und können nur statische Mitglieder enthalten.
    Statische Methoden sind Methoden, die mit dem Schlüsselwort 'static' deklariert werden und aufgerufen werden können,
    ohne dass eine Instanz der Klasse erstellt wird.

    Hauptaspekte statischer Klassen und Methoden:
        - Statische Klassen: Können nicht instanziiert werden und enthalten nur statische Mitglieder.
        - Statische Methoden: Können ohne eine Instanz der Klasse aufgerufen werden.
        - Statische Variablen: Gemeinsame Variablen, die von allen Instanzen der Klasse geteilt werden.
        - Zugriff: Statische Mitglieder werden über den Klassennamen aufgerufen, z.B. ClassName.MethodName().
        - Lebensdauer: Statische Mitglieder existieren für die Dauer der Anwendung und werden erst freigegeben, wenn die Anwendung beendet wird.
        - Anwendungsfälle: Nützlich für Dienstprogrammfunktionen, Hilfsklassen und Konstanten.

    Vorteile statischer Klassen und Methoden:
        - Einfacher Zugriff auf Funktionen ohne Instanziierung.
        - Reduzierung des Speicherverbrauchs durch Vermeidung unnötiger Objekte.
        - Nützlich für Utility- und Helper-Funktionen.
        - Förderung der Code-Organisation durch Gruppierung verwandter Funktionen.
        - Verbesserung der Leistung durch Vermeidung von Objektinstanziierungen.

    ####################################################################################*/

    internal class MathUtility // Wenn eine Klasse nur statische Methoden enthält, sollte sie als static deklariert werden. Darf dann aber keine Instanzmethoden enthalten.
    {
        // Statische Methode zur Addition von zwei Zahlen
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Statische Methode zur Subtraktion von zwei Zahlen
        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    static class _1_Static
    {
        public static void Run()
        {
            // Zugriff auf die statische Methode der Utility-Klasse
            int result = MathUtility.Add(5, 10);
            Console.WriteLine($"Das Ergebnis der Addition ist: {result}");

            result = MathUtility.Subtract(10, 5);
            Console.WriteLine($"Das Ergebnis der Subtraktion ist: {result}");

            // Zugriff auf die Instanzmethode der Utility-Klasse
            MathUtility math = new MathUtility(); //
            result = math.Multiply(4, 5);
            Console.WriteLine($"Das Ergebnis der Multiplikation ist: {result}");
        }
    }
}