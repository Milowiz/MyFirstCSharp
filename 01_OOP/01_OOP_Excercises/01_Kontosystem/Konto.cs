namespace _01_Kontosystem
{
    public class Konto
    {
        public float Balance {get; private set;}
        public  string User {get; set;} = "Thomas";

        public Konto()
        {
            
        }
        
        public void Deposit(float amount, string inputUser)
        {
            if(inputUser == User)
            {
                Balance = Balance + amount;
            }
            
        }
        public override string ToString()
        {
            return $"Hallo {User}, du hast aktuell {Balance} zur Verfügung!";
        }


    }
}