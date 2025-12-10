namespace _03_ShoppingSale
{
    public class Summary
    {
        public decimal NettoSum {get;}
        public decimal Discount {get;}
        public Dictionary<string,decimal> TaxesByCategory {get;}
        public decimal TotalTaxes {get;}
        public decimal EndTotal {get;}

        public Summary(decimal netto, decimal discount, Dictionary<string, decimal> taxesByCategory, decimal totalTaxes, decimal endTotal)
        {
            NettoSum = netto;
            Discount = discount;
            TaxesByCategory = taxesByCategory;
            TotalTaxes = totalTaxes;
            EndTotal = endTotal;
        }
    }
}