using _03_ShoppingSale.BruttoStrategy;
using _03_ShoppingSale.Products;

namespace _03_ShoppingSale.Cart
{
    public class ShoppingCart
    {
        private List<IProduct> _products = new List<IProduct>();
        public static void Run()
        {
            Taxes.AddRule("Hardware", 18);
            Taxes.AddRule("Food", 12);
            Taxes.AddRule("Healthcare", 14);

            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Menu(cart);
            }
        }

        public static void Menu(ShoppingCart cart)
        {
            IDiscount percentDiscount = new PercentDiscount(10); // 15% Rabatt
            IDiscount minValueDiscount = new RequiredValueDiscount(5, 15); // 5€ Rabatt bei mindestens 15€ Bestellwert
            IDiscount flatDiscount = new FlatDiscount(5); // 5€ Rabatt, solange nicht kleiner 0
            IDiscount discount = percentDiscount;
            Console.Clear();
            Console.WriteLine("Was möchtest du machen?");
            Console.WriteLine("[1] Produkte shoppen");
            Console.WriteLine("[2] Produkte aus Warenkorb entfernen");
            Console.WriteLine("[3] Warenkorb anzeigen");
            Console.WriteLine("[4] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            int userChoice = 0;
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:
                    userChoice = cart.GetUserChoice(ProductCatalog.Products, "kaufen");
                    cart.AddProduct(ProductCatalog.Products[userChoice - 1]);
                    ShowCartWithSummary(cart, discount);
                    break;
                case 2:
                    if (cart.GetProducts().Count == 0)
                    {
                        System.Console.WriteLine("Dein Warenkorb ist leer!");
                        Thread.Sleep(1200);
                        break;
                    }
                    int removeChoice = cart.GetUserChoice(cart.GetProducts(), "entfernen");
                    cart.RemoveProduct(cart.GetProducts()[removeChoice - 1]);
                    ShowCartWithSummary(cart, discount);
                    break;
                case 3:
                    if (cart.GetProducts().Count == 0)
                    {
                        System.Console.WriteLine("Dein Warenkorb ist leer!");
                        Thread.Sleep(1200);
                        break;
                    }
                    ShowCartWithSummary(cart, discount);
                    break;
                case 4:
                    Console.WriteLine($"Tschüss bis zum nächsten Mal!");
                    Thread.Sleep(1200);
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

        private decimal CalculateNettoSum(List<IProduct> _product)
        {
            decimal basePrice = 0;
            foreach (var product in _product)
            {
                basePrice += product.Price * product.Quantity;
            }
            return basePrice;
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

        public int GetUserChoice(IEnumerable<IProduct> products, string outputText) //IEnumerable kann IProduct und Product übernommen bekommen, aber man muss es dann wieder zu einer Liste casten, damit man z.b. .Count benutzen kann
        {
            int number = 0;
            bool wrongInput;
            var productList = products.ToList();
            do
            {
                Console.WriteLine($"Was möchtest du {outputText}?");
                System.Console.WriteLine("-------------------------------------------");
                for (int i = 0; i < productList.Count; i++)
                {
                    var product = productList[i];
                    System.Console.WriteLine($"[{i + 1}] {product.Name} - Preis: {product.Price}€ - Kategorie: {product.Category} - Menge: {product.Quantity}");
                }
                wrongInput = HandleInput(ref number) || number < 1 || number > productList.Count;
            } while (wrongInput);
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

        public Summary CalculateAll(IDiscount discountStrategy)
        {
            decimal netto = CalculateNettoSum(_products);
            decimal discount = discountStrategy.CalculateDiscount(netto);
            decimal brutto;

            var taxByCategory = new Dictionary<string, decimal>();
            decimal totalTaxes = 0;

            if((netto-discount)<=0)
            {
             throw new ArgumentException("Der Betrag ist zu gering um einen Rabatt anzuwenden!");   
            }
            else
            {
                brutto = netto - discount;
            }
            foreach (var product in _products)
            {
                var tax = Taxes.GetRule(product.Category).TaxPercent;
                decimal adjustedNetAmount = product.Price * product.Quantity * (brutto / netto);
                decimal taxAmount = Math.Round(adjustedNetAmount * tax / 100, 2, MidpointRounding.AwayFromZero);
                if (taxByCategory.ContainsKey(product.Category))
                {
                    taxByCategory[product.Category] += taxAmount;
                }
                else
                {
                    taxByCategory[product.Category] = taxAmount;
                }
                totalTaxes += taxAmount;
            }
            decimal total = brutto + totalTaxes;
            return new Summary(netto, discount, taxByCategory, totalTaxes, total);

        }

        public void DisplayAllCalculations(Summary summary)
        {
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine($"Zwischensumme netto: {summary.NettoSum:F2}€");
            System.Console.WriteLine($"Rabatt: {summary.Discount:F2}€");
            foreach (var taxByCategory in summary.TaxesByCategory)
            {
                System.Console.WriteLine($"Steuer: {taxByCategory.Key}: {taxByCategory.Value:F2}€");
            }
            System.Console.WriteLine($"Gesamtsteuer: {summary.TotalTaxes:F2}€");
            System.Console.WriteLine($"Endsumme brutto: {summary.EndTotal:F2}€");
            System.Console.WriteLine("---------------------------------------------");

        }

        private static void ShowCartWithSummary(ShoppingCart cart, IDiscount discount)
        {
            System.Console.WriteLine("Der Warenkorb: ");
            cart.ShowUserChosenList(cart.GetProducts());
            Summary summary = cart.CalculateAll(discount);
            cart.DisplayAllCalculations(summary);
            System.Console.WriteLine("Taste drücken um fortzufahren ...");
            Console.ReadKey();
        }

    }
}