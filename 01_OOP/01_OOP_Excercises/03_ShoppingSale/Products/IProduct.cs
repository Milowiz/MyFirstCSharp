namespace _03_ShoppingSale.Products
{
    public interface IProduct
    {
        public string Name{get;set;}
        public float Price{get;set;}
        public ushort AmountLeft{get;set;}
        public string Category{get;set;}
        public ushort Quantity{get;set;}

    }
}