namespace _03_ShoppingSale.BruttoStrategy
{
    public interface IDiscount
    {
        decimal CalculateDiscount(decimal nettoSum);
        string Name { get; }
    }
}