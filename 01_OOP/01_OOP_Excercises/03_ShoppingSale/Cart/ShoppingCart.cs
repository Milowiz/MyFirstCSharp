using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using _03_ShoppingSale.Products;

namespace _03_ShoppingSale.Cart
{
    public class ShoppingCart
    {
        private List<IProduct> _products = new List<IProduct>();
        public static void Run()
        {
            ShoppingCart cart = new ShoppingCart();
            while (true)
            {
                Menu(cart);
            }

        }

        public static void Menu(ShoppingCart cart)
        {

            Console.Clear();
            Console.WriteLine("Was möchtest du machen?");
            Console.WriteLine("[1] Produkte shoppen");
            Console.WriteLine("[2] Produkte aus Warenkorb entfernen");
            Console.WriteLine("[3] Warenkorb anzeigen");
            Console.WriteLine("[4] Von allen Objekten");
            Console.WriteLine("[5] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            int userChoice = 0;
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:

                    userChoice = cart.UserShopping();
                    cart.AddProduct(ProductCatalog.Products[userChoice - 1]);
                    System.Console.WriteLine("Der Warenkorb: ");
                    cart.ShowUserChosenList(cart.GetProducts());
                    Thread.Sleep(2500);
                    break;
                case 2:
                    cart.ShowUserChosenList(cart.GetProducts());
                    cart.RemoveProduct(ProductCatalog.Products[userChoice - 1]);
                    System.Console.WriteLine("Der Warenkorb: ");
                    //cart.ShowUserChosenList(cart.GetProducts());
                    Thread.Sleep(2500);
                    //cart.ShowUserChosenList(cart.GetProducts());
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine($"Tschüss bis zum nächsten Mal!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe bitte versuche es nochmal!");
                    break;
            }
        }
        public void AddProduct(IProduct product)
        {
            var existingProduct = _products.Find(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Quantity++;
            }
            else
            {

                product.Quantity = 1;
                _products.Add(product);
                System.Console.WriteLine($"Produkt hinzugefügt: {product.Name}");
            }
        }

        public void RemoveProduct(IProduct product)
        {
            var existingProduct = _products.Find(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                if (existingProduct.Quantity > 1)
                {
                    existingProduct.Quantity--;

                }

                else
                {
                    _products.Remove(existingProduct);
                    System.Console.WriteLine($"Produkt entfernt: {existingProduct.Name}");
                }
            }
            else
            {
                {
                    System.Console.WriteLine("Produkt nicht im Warenkorb gefunden!");
                }
            }

        }
        public List<IProduct> GetProducts()
        {
            return new List<IProduct>(_products);
        }
        public void CalculateTotal(List<Product> _product)
        {

        }
        public void ShowShoppingList()
        {
            int counter = 1;
            foreach (var product in ProductCatalog.Products)
            {
                System.Console.WriteLine($"[{counter}]{product.Name} - Preis: {product.Price}€ - Kategorie: {product.Category} - Menge: {product.Quantity}");
                counter++;
            }
        }
        public int UserShopping()
        {
            string iNumber;
            int number;
            bool wrongInput = true;
            do
            {
                Console.WriteLine("Was möchtest du kaufen?");
                ShowShoppingList();
                iNumber = Console.ReadLine() ?? "";
                if (!int.TryParse(iNumber, out number) == true)
                {
                    System.Console.WriteLine("Falsche Eingabe!");
                    Thread.Sleep(1500);
                    wrongInput = true;

                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);
            return number;
        }
        public void ShowUserChosenList(List<IProduct> _product)
        {
            int counter = 0;
            foreach (var product in _product)
            {
                System.Console.WriteLine($"[{counter}]{product.Name} - Preis: {product.Price}€ - Kategorie: {product.Category} - Menge: {product.Quantity}");
                counter++;
            }
        }

    }
}