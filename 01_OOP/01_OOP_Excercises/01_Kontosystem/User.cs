namespace _01_Kontosystem
{
    public class User
    {
        private string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
        
        public void InitializeKonto()
        {
        Konto konto = new Konto($"{Name}");
        }
    }
}