namespace _03_ShoppingSale.Products
{
    public class Product : IProduct
    {
        public string Name{get; set;}
        public float Price{get; set;}
        public ushort AmountLeft{get;set;}
        public string Category{get;set;}
        public ushort Quantity{get;set;}
        public Product(string name, float price, ushort amountLeft, string category, ushort quantity)
        {
            Name = name;
            Price = price;
            AmountLeft = amountLeft;
            Category = category;
            Quantity = quantity;
        }
        public void IncrementQuantity()
        {
            Quantity++;
        }        
        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}