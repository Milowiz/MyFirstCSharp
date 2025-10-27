using System.Security.Cryptography.X509Certificates;

namespace _01_OOP
{

    public class ClassesAndObjects
    {
        public static void Run()
        {
            // keyword "new" instanziert ein Objekt 
            Car myCar = new Car("Nissan","GTR32",9000);
            myCar.SetBrand("Peugeot");
            myCar.weight = 2000;
            myCar.model = "408 GT";
            myCar.power = 9000;
            myCar.colour = "Red";

            
            myCar.Drive();
        }
    }
    class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public ushort Power { get; private set; }
        // Attribute (Variablen die einem Objekt zugehörig sind); Klassenattribute werden mit Großbuchstbaen begonnen
        public float weight;
        public string colour;
        public string brand;
        public ushort power;
        public string model;

        //Konstruktoren
        public Car(string brand, string model, ushort power)
        {
            Brand = brand;
            Model = model;
            Power = power;
        }
        // Methoden (Funktionen die einem Objekt zugehörig sind)
        public void Drive()
        {
            Console.WriteLine($"The {brand} {model} is driving with {power} hp");
        }

        public void Honk()
        {
            Console.WriteLine("Beep Beep!");
        }
        // Getter bzw. Setter-Methoden
        // Settermethoden
        public void SetModel(string model)
        {
            this.model = model;
        }
        public void SetBrand(string brand)
        {
            this.brand = brand;
        }
        public void SetPower(ushort power)
        {
            this.power = power;
        }
        // Gettermethoden
        public ushort GetPower()
        {
            return this.power;
        }
    }

}