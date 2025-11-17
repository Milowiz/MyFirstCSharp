namespace _01_Kontosystem
{
    public class Konto
    {
        public float Balance {get; private set;}
        public  string User {get; set;} = "Thomas";

        public Konto()
        {
            
        }
        
        public override string ToString()
        {
            return $"Hallo {User}, du hast aktuell {Balance} zur Verfügung!";
        }


    }
}