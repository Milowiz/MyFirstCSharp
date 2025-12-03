namespace _03_ShoppingSale.BruttoStrategy
{
    public class PercentDiscount : IDiscount
    {
        private readonly decimal _percent;
        public string Name => $"Prozent-Rabatt ({_percent}%)";
        public PercentDiscount(decimal percent)
        {

            if (percent < 0 || percent > 100)
            {
                throw new ArgumentException("Prozentwert muss zwischen 0 und 100 liegen.");
            }
            _percent = percent;
        }
        public decimal CalculateDiscount(decimal nettoSum)
        {
            return Math.Round(nettoSum * _percent / 100, 2, MidpointRounding.AwayFromZero);
        }
    }
}