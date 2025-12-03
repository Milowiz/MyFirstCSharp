namespace _03_ShoppingSale.Products
{
    public interface IProduct
    {
        public string Name{get;set;}
        public decimal Price{get;set;}
        public string Category{get;set;}
        public ushort Quantity{get;set;}

    }
}