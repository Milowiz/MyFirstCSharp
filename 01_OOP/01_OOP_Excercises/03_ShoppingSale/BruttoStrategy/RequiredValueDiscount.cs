namespace _03_ShoppingSale.BruttoStrategy
{
    public class RequiredValueDiscount : IDiscount
    {
        private readonly decimal _discount;
        private readonly decimal _minValue;
        public string Name => $"Schwellen-Rabatt (ab {_minValue}€: {_discount}€";
        public RequiredValueDiscount(decimal discount, decimal minValue)
        {
            _discount = discount;
            _minValue = minValue;
        }
        public decimal CalculateDiscount(decimal nettoSum)
        {
            if(nettoSum >= _minValue)
            {
                return Math.Round(Math.Min(_discount, nettoSum), 2, MidpointRounding.AwayFromZero);
            }
            return 0;
        }
    }
}