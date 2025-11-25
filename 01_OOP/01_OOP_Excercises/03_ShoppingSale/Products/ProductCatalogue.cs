namespace _03_ShoppingSale.Products
{
public static class ProductCatalog
{
    public static List<Product> Products = new()
    {
        new Product("AMD Ryzen 7 7800X3D", 338f, 10, "Hardware", 0),
        new Product("Erdbeer Marmelade", 4f, 5, "Food", 0),
        new Product("Oral-B UltraThin Precision extra-weich", 6f, 20, "Healthcare", 0),
        new Product("ASUS ROG Strix XG27ACS", 230f, 15, "Hardware", 0)
    };
}
}