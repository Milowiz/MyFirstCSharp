using _02_OOP._00_Exercises;

namespace _02_OOP
{
    internal class Program
    {
        /* ############################################################################################

        Objektorientierte Programmierung (OOP) in C#

        OOP ist ein Programmierparadigma, das auf dem Konzept von "Objekten" basiert. 
        Objekte sind Instanzen von Klassen, die Daten (Eigenschaften) und Verhalten (Methoden) kapseln.

        Die vier Hauptprinzipien der OOP sind:
            - Kapselung: Das Bündeln von Daten und Methoden, die auf diese Daten zugreifen, innerhalb einer Klasse.
            - Vererbung: Das Erstellen neuer Klassen basierend auf bestehenden Klassen, um Code wiederzuverwenden und zu erweitern.
            - Polymorphismus: Die Fähigkeit, dass verschiedene Klassen auf die gleiche Methode unterschiedlich reagieren können.
            - Abstraktion: Das Verbergen komplexer Implementierungsdetails und das Bereitstellen einer einfachen Schnittstelle.

        ############################################################################################ */
        static void Main(string[] args)
        {
            Mainecoon cat = new Mainecoon("Schnurrli", 'w', 3, 13, "Mainecoon");
            cat.Eat();
            cat.Sleep();
            cat.Meow();
            Console.WriteLine(cat.RetrunSecret("meow123"));
            Console.WriteLine(cat.RetrunMaineCoonsSecret("Fetzn123"));

            Dog myDog = new Dog("Frenzy", 'm', 5, 25, "Dackel");
            myDog.Eat();
            myDog.Sleep();
            myDog.Bark();
            System.Console.WriteLine(myDog.RetrunSecret("wrongCode"));

        }
    }

    // Baseclass or Parentclass
    public class Animal
    {
        // Public attributes
        public char Gender { get; set; }
        public int NumberOfLegs { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Private attributes
        private string Secret { get; set; } = "I love bones";

        // Basic constructor
        public Animal(string name, char gender, int numberOfLegs, int age)
        {
            Name = name;
            Gender = gender;
            NumberOfLegs = numberOfLegs;
            Age = age;
        }

        /// <summary>
        /// Eat method of the animal
        /// </summary>
        public void Eat()
        {
            System.Console.WriteLine($"{Name} is eating.");
        }

        /// <summary>
        /// Sleep method of the animal
        /// </summary>
        public void Sleep()
        {
            System.Console.WriteLine($"{Name} is sleeping.");
        }

        /// <summary>
        /// Walk method of the animal
        /// </summary>
        public void Walk()
        {
            System.Console.WriteLine($"{Name} is walking.");
        }


        /// <returns>The secret of the animal object</returns>
        private string RevealSecret()
        {
            return Secret;
        }

        /// <summary>
        /// Check if the invoker of this method has access
        /// </summary>
        /// <param name="gotAccess">Indicates if the invoker of the method has access</param>
        /// <returns>The secret if the invoke has access; otherwise an empty string</returns>
        protected string ShowSecret(bool gotAccess)
        {
            if (!gotAccess)
            {
                System.Console.WriteLine("Access denied. Incorrect Code.");
                return "You got no access";
            }

            return RevealSecret();
        }
    }

    // Childclass or Subclass
    public class Cat : Animal
    {
        // Public attributes
        public string Race { get; set; }


        // Basic constructor
        public Cat(string name, char gender, int numberOfLegs, int age, string race)
            : base(name, gender, numberOfLegs, age)
        {
            Race = race;
        }

        /// <summary>
        /// Meow method of Cat class
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Name} is meowing!");
        }

        public string RetrunSecret(string code)
        {
            bool gotAccess = code == "meow123";
            return ShowSecret(gotAccess);
        }
    }

    public class Mainecoon : Cat
    {

        public Mainecoon(string name, char gender, int numberOfLegs, int age, string race)
        : base(name, gender, numberOfLegs, age, race)
        {

        }

        public string RetrunMaineCoonsSecret(string code)
        {
            bool gotAccess = code == "Fetzn123";
            return ShowSecret(gotAccess);
        }
    }

    public class Dog : Animal
    {

        public string Race { get; set; }

        public Dog(string name, char gender, int numberOfLegs, int age, string race)
        : base(name, gender, numberOfLegs, age)
        {
            Race = race;
        }

        public void Bark()
        {
            System.Console.WriteLine($"{Name} is barking.");
        }

        public string RetrunSecret(string code)
        {
            bool gotAccess = code == "woof123";
            return ShowSecret(gotAccess);
        }

    }

}