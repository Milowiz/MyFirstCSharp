using System.Data;
using System.Net;
using _03_ShoppingSale.Products;
using _03_ShoppingSale.Cart;

namespace _03_ShoppingSale.BruttoStrategy
{
    public class Taxes
    {
        private static List<CategoryRule> Rules = new List<CategoryRule>();
        public static void AddRule(string category, decimal tax)
        {
            CategoryRule existing = Rules.FirstOrDefault(r => r.Category == category); //LINQ = Wie SELECT bei Datenbanken
            if(existing != null)
            {
                existing.TaxPercent = tax;
            }
            else
            {
                Rules.Add(new CategoryRule(category,tax));
            }
        }
        public static CategoryRule GetRule(string category)
        {
            return Rules.FirstOrDefault(r => r.Category == category) ?? new CategoryRule(category, 0);
        }
    }
}