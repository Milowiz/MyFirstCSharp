using System.ComponentModel;
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
            Taxes.AddRule("Hardware", 10, 0);
            Taxes.AddRule("Food", 0, 12);
            Taxes.AddRule("Healthcare", 0, 14);
            ShoppingCart cart = new ShoppingCart();
            while (true)
            {
                Menu(cart);
            }

        }

        public static void Menu(ShoppingCart cart)
        {
            double total;
            double roundedTotal;

            Console.Clear();
            Console.WriteLine("Was möchtest du machen?");
            Console.WriteLine("[1] Produkte shoppen");
            Console.WriteLine("[2] Produkte aus Warenkorb entfernen");
            Console.WriteLine("[3] Warenkorb anzeigen");
            Console.WriteLine("[4] Alles ansehen");
            Console.WriteLine("[5] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            int userChoice = 0;
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:

                    userChoice = cart.GetUserChoice(ProductCatalog.Products, "kaufen");
                    cart.AddProduct(ProductCatalog.Products[userChoice - 1]);
                    total = cart.GetTotal(cart.GetProducts());
                    roundedTotal = Math.Round(total,2);
                    System.Console.WriteLine("Der Warenkorb: ");
                    cart.ShowUserChosenList(cart.GetProducts());
                    System.Console.WriteLine($"Die Zwischensumme(inkl. Steuern) beträgt: {roundedTotal}€");
                    Thread.Sleep(2500);
                    break;
                case 2:
                    if (cart.GetProducts().Count == 0)
                    {
                        System.Console.WriteLine("Dein Warenkorb ist leer!");
                        Thread.Sleep(1500);
                        break;
                    }
                    int removeChoice = cart.GetUserChoice(cart.GetProducts(), "entfernen");
                    cart.RemoveProduct(cart.GetProducts()[removeChoice - 1]);
                    System.Console.WriteLine("Der Warenkorb: ");
                    cart.ShowUserChosenList(cart.GetProducts());
                    Thread.Sleep(1500);
                    //cart.ShowUserChosenList(cart.GetProducts());
                    break;
                case 3:
                    
                    System.Console.WriteLine("Der Warenkorb: ");
                    cart.ShowUserChosenList(cart.GetProducts());
                    total = cart.GetTotal(cart.GetProducts());
                    roundedTotal = Math.Round(total, 2);
                    Console.WriteLine($"Gesamtbetrag(inkl.Steuern): {roundedTotal}€"); 

                    Thread.Sleep(2000);
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
        public bool HandleInput(ref int number)
        {
            string iNumber;

            iNumber = Console.ReadLine() ?? "";
            if (!int.TryParse(iNumber, out number) == true)
            {
                System.Console.WriteLine("Falsche Eingabe!");
                Thread.Sleep(1500);
                return true;

            }
            else
            {
                return false;
            }
        }
        public int GetUserChoice(IEnumerable<IProduct> products, string outputText) //IEnumerable kann IProduct und Product übrnommen bekommen, aber man muss es dann wieder zu einer Liste casten, damit man z.b. .Count benutzen kann
        {
            int number = 0;
            bool wrongInput;
            var productList = products.ToList();
            do
            {
                Console.WriteLine($"Was möchtest du {outputText}");
                for (int i = 0; i < productList.Count; i++)
                {
                    var product = productList[i];
                    System.Console.WriteLine($"[{i + 1}] {product.Name} - Preis: {product.Price}€ - Kategorie: {product.Category} - Menge: {product.Quantity}");
                }
                wrongInput = HandleInput(ref number) || number < 1 || number > productList.Count;
                if (wrongInput)
                {
                    System.Console.WriteLine("Ungültige Auswahl!");
                    Thread.Sleep(1500);
                }


            } while (wrongInput);
            return number;
        }
        public int UserShopping()
        {
            int number = 0;
            do
            {
                Console.WriteLine("Was möchtest du kaufen?");
                ShowShoppingList();
                HandleInput(ref number);

            } while (HandleInput(ref number));
            return number;
        }
        public void ShowUserChosenList(List<IProduct> _product)
        {
            int counter = 1;
            foreach (var product in _product)
            {
                System.Console.WriteLine($"[{counter}]{product.Name} - Preis: {product.Price}€ - Kategorie: {product.Category} - Menge: {product.Quantity}");
                counter++;
            }
        }
        public float GetTotal(List<IProduct> _product)
        {
            float total = 0;
            float basePrice = 0;
            foreach (var product in _product)
            {
                basePrice += product.Price * product.Quantity;

                var rule = Taxes.GetRule(product.Category);

                basePrice -= basePrice * (rule.DiscountPercent / 100);
                basePrice += basePrice * (rule.TaxPercent / 100);

                total += basePrice;
            }
            return total;
        }

    }
}