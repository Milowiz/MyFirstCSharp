
using System.Data;
using System.Net;
using _03_ShoppingSale.Products;

namespace _03_ShoppingSale.Cart
{
    public static class Taxes
    {
        private static List<CategoryRule> Rules = new List<CategoryRule>();
        public static void AddRule(string category, float discount, float tax)
        {
            var existing = Rules.FirstOrDefault(r => r.Category == category);
            if(existing != null)
            {
                existing.DiscountPercent = discount;
                existing.TaxPercent = tax;
            }
            else
            {
                Rules.Add(new CategoryRule(category,discount,tax));
            }
        }
        public static CategoryRule GetRule(string category)
        {
            return Rules.FirstOrDefault(r => r.Category == category) ?? new CategoryRule(category, 0, 0);
        }
    }
}