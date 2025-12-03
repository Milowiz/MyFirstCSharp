namespace _03_ShoppingSale.BruttoStrategy
{
    public class FlatDiscount : IDiscount
    {
        private readonly decimal _amount;
        public string Name => $"Fixer-Rabatt ({_amount}€)";
        public FlatDiscount(decimal amount)
        {

            if (amount < 0)
            {
                throw new ArgumentException("Rabattbetrag darf nicht negativ sein!");
            }
            _amount = amount;

        }
        public decimal CalculateDiscount(decimal nettoSum)
        {
            return Math.Round(Math.Min(_amount, nettoSum), 2, MidpointRounding.AwayFromZero);
        }

    }
}