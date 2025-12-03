namespace _03_ShoppingSale.Cart
{
    public class CategoryRule
    {
        public string Category {get; set;}
        public decimal TaxPercent{get;set;}

        public CategoryRule(string category, decimal tax)
        {
            Category = category;
            TaxPercent = tax;
        }
    }
}