using System.ComponentModel;

namespace _02_OOP
{
    /* ############################################################################################

        Polymorphismus (Polymorphism) in C#

        Polymorphismus ist ein Konzept der objektorientierten Programmierung, das es Objekten
        ermöglicht, auf die gleiche Methode unterschiedlich zu reagieren, abhängig von ihrem
        tatsächlichen Typ zur Laufzeit.

        Hauptaspekte des Polymorphismus:
            - Methodenüberschreibung (Method Overriding): Eine abgeleitete Klasse kann eine Methode
              der Basisklasse mit dem gleichen Namen und der gleichen Signatur neu definieren.
            - Virtuelle Methoden: In der Basisklasse deklarierte Methoden können als "virtual" markiert
              werden, um anzugeben, dass sie in abgeleiteten Klassen überschrieben werden können.
            - Abstrakte Klassen und Methoden: Abstrakte Klassen können abstrakte Methoden enthalten,
              die in den abgeleiteten Klassen implementiert werden müssen.
            - Schnittstellen (Interfaces): Schnittstellen definieren Verträge, die von verschiedenen
              Klassen implementiert werden können, wodurch polymorphes Verhalten ermöglicht wird.
            - Laufzeitbindung (Dynamic Binding): Die Entscheidung, welche Methode aufgerufen wird,
              erfolgt zur Laufzeit basierend auf dem tatsächlichen Typ des Objekts.

        Vorteile des Polymorphismus:
            - Flexibilität und Erweiterbarkeit des Codes.
            - Ermöglicht die Verwendung von allgemeinen Schnittstellen für verschiedene Datentypen.
            - Reduziert die Notwendigkeit von bedingten Anweisungen zur Typprüfung.
            - Unterstützt das Prinzip "Program to an interface, not an implementation".
            - Erleichtert die Wartung und das Hinzufügen neuer Funktionalitäten.

        Überschreibung:
            - Bei der Überschreibung (Overriding) wird eine Methode in einer abgeleiteten Klasse
              neu definiert, um das Verhalten der Methode in der Basisklasse zu ändern. Die Methode in der
              Basisklasse muss als "virtual" deklariert sein, und die Methode in der abgeleiteten Klasse muss das
              Schlüsselwort "override" verwenden.

        Überschreiben vs. Überladen:
            - Überschreiben (Overriding): Eine Methode in einer abgeleiteten Klasse ersetzt die
              Implementierung der gleichen Methode in der Basisklasse.
              Auch genannt: Laufzeit-Polymorphismus.
            - Überladen (Overloading): Mehrere Methoden mit dem gleichen Namen, aber unterschiedlichen
              Parametertypen oder -anzahlen innerhalb derselben Klasse.
              Auch genannt: Kompilierzeit-Polymorphismus.

        LHS vs. RHS:
            - LHS (Left Hand Side): Bezieht sich auf den Typ der Variablen oder des Referenztyps
              auf der linken Seite einer Zuweisung. Dies bestimmt, welche Methoden und Eigenschaften
              zur Kompilierzeit verfügbar sind.
              CompileTime Type.
            - RHS (Right Hand Side): Bezieht sich auf den tatsächlichen Typ des Objekts oder der
              Instanz auf der rechten Seite einer Zuweisung. Dies bestimmt, welche Methode zur
              Laufzeit aufgerufen wird, insbesondere bei überschriebenen Methoden.
              Runtime Type.

    ############################################################################################ */

    class _05_Polymorphism
    {

        // Basisklasse
        abstract class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }

            // Abstrakte Methode, die in abgeleiteten Klassen implementiert werden muss
            public abstract void Speak();

            // Virtuelle Methode, die in abgeleiteten Klassen überschrieben werden kann
            public virtual void Sleep()
            {
                Console.WriteLine($"{Name} is sleeping.");
            }

            public void Walk()
            {
                Console.WriteLine($"{Name} is walking.");
            }

            // Überladene Methode
            public void Walk(int distance)
            {
                Console.WriteLine($"{Name} walked {distance} meters.");
            }
        }

        // Abgeleitete Klasse Dog
        class Dog : Animal
        {
            public Dog(string name, int age) : base(name, age) { }

            // Überschreiben der abstrakten Speak-Methode
            public override void Speak()
            {
                Console.WriteLine($"{Name} says Woof!");
            }

            // Überschreiben der virtuellen Sleep-Methode
            public override void Sleep()
            {
                Console.WriteLine($"{Name} the dog is sleeping.");
            }

            public void Fetch()
            {
                Console.WriteLine($"{Name} is fetching the ball.");
            }
        }

        // Abgeleitete Klasse Cat
        class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age) { }

            // Überschreiben der Speak-Methode
            public override void Speak()
            {
                Console.WriteLine($"{Name} says Meow!");
            }

            public void Scratch()
            {
                Console.WriteLine($"{Name} is scratching the furniture.");
            }

        }

        public static void Run()
        {
            // Erstellen einer Liste von Tieren
            List<Animal> animals = new List<Animal>
            {
                new Dog("Buddy", 3),
                new Cat("Whiskers", 2)
            };

            // Iterieren über die Liste und Aufrufen der Speak-Methode
            foreach (var animal in animals)
            {
                animal.Speak(); // Polymorpher Aufruf der Speak-Methode
                animal.Sleep(); // Polymorpher Aufruf der Sleep-Methode

                // animal.Fetch(); // Fehler: Fetch ist nicht in der Basisklasse definiert. Man müsste den Typ casten.
                // Dog dog = (Dog)animal; // Korrekt, wenn es sicher ist, dass es ein Hund ist.
                // dog.Fetch(); // Jetzt funktioniert es

                // animal.Scratch(); // Fehler: Scratch ist nicht in der Basisklasse definiert. Man müsste den Typ casten.
                // Cat cat = (Cat)animal; // Korrekt, wenn es sicher ist, dass es eine Katze ist.
                // cat.Scratch(); // Jetzt funktioniert es
            }
        }
    }
}