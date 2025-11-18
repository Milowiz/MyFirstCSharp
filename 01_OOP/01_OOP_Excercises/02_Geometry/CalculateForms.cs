

namespace _02_Geometry
{
    public class CalculateForms
    {
        public CalculateForms()
        {

        }

        public static void Run()
        {
           CalculateForms calculate = new CalculateForms();
           Menu(calculate);
           calculate.CalculateTotalArea();

        }
        public void CalculateTotalArea()
        {


            List<IForms> forms = new List<IForms>
            {
                new Rectangle(3,5),
                new Circle(6),
                new Triangle(6,4,5)
            };

            double result = 0;
            foreach (var form in forms)
            {

                result += form.CalculateArea();

            }
            Console.WriteLine($"Die Gesamtfläche beträgt: {result.ToString("F2")}");

        }
        public static void Menu(CalculateForms calculate)
        {
            Console.Clear();
            Console.WriteLine($"------- Konto von: {calculate.CalculateTotalArea} --------");
            Console.WriteLine("Von was möchtest du die Flache und den Umfang berechnen?");
            Console.WriteLine("[1] Ein Rechteck");
            Console.WriteLine("[2] Ein Kreis");
            Console.WriteLine("[3] Ein Dreieck");
            Console.WriteLine("[4] Verlassen");
            string userInput = Console.ReadLine() ?? "";
            float.TryParse(userInput, out float vUserInput);
            switch (vUserInput)
            {
                case 1:
                    calculate.CalculateTotalArea();
                    Thread.Sleep(2000);
                    break;
                case 2:
                    calculate.;
                    Thread.Sleep(2000);
                    break;
                case 3:
                    calculate.;
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($"Tschüss {calaculate} bis zum nächsten Mal!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe bitte versuche es nochmal!");
                    break;
            }
        }
    }


}