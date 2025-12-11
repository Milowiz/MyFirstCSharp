namespace _01_Kontosystem
{
    public class User
    {
        public string Name { get; private set; }
        public Konto? Konto { get; private set; }
        public User(string name)
        {
            this.Name = name;
        }

        public void OpenAccount(float fee = 0, float startBalance = 0)
        {
            if (Konto != null) throw new InvalidOperationException("User hat bereits ein Konto");
            Konto = new Konto(owner: this, fee, startBalance);
        }

        public override string ToString() => Name;
    }
}