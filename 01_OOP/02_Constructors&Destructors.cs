namespace _02_OOP
{
    /* ############################################################################################

        Konstruktoren und Destruktoren in C#

        Konstruktoren:
            - Spezielle Methoden, die aufgerufen werden, wenn eine Instanz (Objekt) einer Klasse erstellt wird.
            - Haben den gleichen Namen wie die Klasse und keinen Rückgabetyp.
            - Dienen dazu, die Attribute eines Objekts zu initialisieren und notwendige Ressourcen bereitzustellen.
            - Können Parameter haben, um unterschiedliche Initialisierungen zu ermöglichen.
            - Wenn kein Konstruktor definiert ist, stellt der Compiler einen Standardkonstruktor bereit.

        Destruktoren:
            - Spezielle Methoden, die aufgerufen werden, wenn ein Objekt zerstört oder aus dem Speicher entfernt wird.
            - Haben den gleichen Namen wie die Klasse, jedoch mit einem vorangestellten Tilde-Zeichen (~) und keinen Rückgabetyp.
            - Dienen dazu, Ressourcen freizugeben, die das Objekt während seiner Lebensdauer verwendet hat (z.B. Datei-Handles, Netzwerkverbindungen).
            - Werden automatisch vom Garbage Collector aufgerufen, wenn das Objekt nicht mehr benötigt wird.
            - In C# sind Destruktoren weniger gebräuchlich, da der Garbage Collector die Speicherverwaltung übernimmt.
            - Destruktoren können nicht explizit aufgerufen werden und haben keine Parameter.

        ############################################################################################ */

    internal class Person
    {
        // Attribute der Klasse Person
        public string Name { get; set; }
        public int Age { get; set; }

        // Konstruktor der Klasse Person
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"Person {Name} wurde erstellt.");
        }

        // Methode der Klasse Person
        public void Introduce()
        {
            Console.WriteLine($"Hallo, mein Name ist {Name} und ich bin {Age} Jahre alt.");
        }

        // Destruktor der Klasse Person
        ~Person()
        {
            Console.WriteLine($"Person {Name} wird zerstört.");
        }
    }

    public class _02_ConstructorsAndDestructors
    {
        public static void Run()
        {
            // Erstellen eines Objekts der Klasse Person
            Person person1 = new Person("Alice", 30);
            person1.Introduce();

            // Erstellen eines weiteren Objekts der Klasse Person
            Person person2 = new Person("Bob", 25);
            person2.Introduce();
        }
    }
}