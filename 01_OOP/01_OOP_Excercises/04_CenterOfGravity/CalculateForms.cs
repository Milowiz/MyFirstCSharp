namespace _04_CenterOfGravity
{
    public class CalculateForms
    {
        public CalculateForms()
        {

        }

        public static void Run()
        {
            while(true)
            {
            CalculateForms calculate = new CalculateForms();
            Menu(calculate);
            }

        }
        public static void Menu(CalculateForms calculate)
        {
            double length = 0, width = 0;
            double radius = 0;
            double sideA = 0, sideB = 0, sideC = 0;
            Console.Clear();
            Console.WriteLine("Von was möchtest du die Flache und den Umfang berechnen?");
            Console.WriteLine("[1] Ein Rechteck");
            Console.WriteLine("[2] Ein Kreis");
            Console.WriteLine("[3] Ein Dreieck");
            Console.WriteLine("[4] Von allen Objekten");
            Console.WriteLine("[5] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:

                    calculate.RectangleInput(ref length, ref width);
                    Rectangle rectangle = new Rectangle(length, width);
                    System.Console.WriteLine($"Die Fläche beträgt: {rectangle.CalculateArea()}\n Der Umfang beträgt: {rectangle.CalculatePerimeter()}");
                    Thread.Sleep(2000);
                    break;
                case 2:

                    calculate.CircleInput(ref radius);
                    Circle circle = new Circle(radius);
                    System.Console.WriteLine($"Die Fläche beträgt: {circle.CalculateArea()}\n Der Umfang beträgt: {circle.CalculatePerimeter()}");
                    Thread.Sleep(2000);
                    break;
                case 3:

                    calculate.TriangleInput(ref sideA, ref sideB, ref sideC);
                    Triangle triangle = new Triangle(sideA, sideB, sideC);
                    System.Console.WriteLine($"Die Fläche beträgt: {triangle.CalculateArea()}\nDer Umfang beträgt: {triangle.CalculatePerimeter()}");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    calculate.RectangleInput(ref length, ref width);
                    calculate.CircleInput(ref radius);
                    calculate.TriangleInput(ref sideA, ref sideB, ref sideC);
                    rectangle = new Rectangle(length, width);
                    circle = new Circle(radius);
                    triangle = new Triangle(sideA, sideB, sideC);
                    double result = rectangle.CalculateArea() + circle.CalculateArea() + triangle.CalculateArea();
                    System.Console.WriteLine($"Die Gesamtfläche beträgt: {result.ToString("F2")}");
                    Thread.Sleep(2000);
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
        public bool CheckForValidInput(string playerInput)
        {

            if (double.TryParse(playerInput, out double input))
            {
                if (input <= 0)
                {
                    System.Console.WriteLine("Bitte nur gültige positive Zahlen eingeben!");
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }


        }
        public void RectangleInput(ref double vLength, ref double vWidth)
        {
            string lengthInput;
            string widthInput;
            double vInput;

            do
            {
                Console.WriteLine("Bitte Länge eingeben: ");
                lengthInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(lengthInput));
            vLength = double.Parse(lengthInput);
            do
            {
                Console.WriteLine("Bitte Breite eingeben: ");
                widthInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(widthInput));
            vWidth = double.Parse(widthInput);

        }
        public void CircleInput(ref double vRadius)
        {
            string radiusInput;

            do
            {
                Console.WriteLine("Bitte Radius eingeben: ");
                radiusInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(radiusInput));
            vRadius = double.Parse(radiusInput);

        }
        public void TriangleInput(ref double vSideA, ref double vSideB, ref double vSideC)
        {
            string sideAInput;
            string sideBInput;
            string sideCInput;


            do
            {
                Console.WriteLine("Bitte Länge von Seite A eingeben: ");
                sideAInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(sideAInput));
            vSideA = double.Parse(sideAInput);
            do
            {
                Console.WriteLine("Bitte Länge von Seite B eingeben: ");
                sideBInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(sideBInput));
            vSideB = double.Parse(sideBInput);
            do
            {
                Console.WriteLine("Bitte Länge von Seite C eingeben: ");
                sideCInput = Console.ReadLine() ?? "";
            }
            while (!CheckForValidInput(sideCInput));
            vSideC = double.Parse(sideCInput);

        }

    }


}