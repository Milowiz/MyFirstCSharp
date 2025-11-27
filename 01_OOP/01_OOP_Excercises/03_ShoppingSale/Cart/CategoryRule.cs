namespace _03_ShoppingSale.Cart
{
    public class CategoryRule
    {
        public string Category {get; set;}
        public float DiscountPercent {get;set;}
        public float TaxPercent{get;set;}

        public CategoryRule(string category, float discount, float tax)
        {
            Category = category;
            DiscountPercent = discount;
            TaxPercent = tax;
        }
    }
}