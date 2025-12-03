namespace _03_ShoppingSale.Products
{
    public class Product : IProduct
    {
        public string Name{get;set;}
        public decimal Price{get;set;}
        public string Category{get;set;}
        public ushort Quantity{get;set;}
        public Product(string name, decimal price, string category, ushort quantity)
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
        }
        
    }
}