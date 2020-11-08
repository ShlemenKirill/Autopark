using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {        

            VenicleType[] types = new VenicleType[] 
            { 
                new VenicleType("Bus", 1.2), 
                new VenicleType("Car", 1), 
                new VenicleType("Rink", 1.5), 
                new VenicleType("Tractor", 1.2) 
            };

            Venicle[] venicles = new Venicle[]
            {
                new Venicle(types[0], "Volkswagen Crafter", "5427 AX-7", 2022, "2015", Colors.Blue, 376000),
                new Venicle(types[0], "Volkswagen Crafter", "6427 AA-7", 2500, "2014", Colors.White, 376000),
                new Venicle(types[0], "Electric Bus E321", "6785 BA-7", 12080, "2019", Colors.Green, 20451),
                new Venicle(types[1], "Golf 5", "8682 AX-7", 1200, "2006", Colors.Gray, 230451),
                new Venicle(types[1], "Tesla Model S 70D", "E001 AA-7", 2200, "2019", Colors.White, 10454),
                new Venicle(types[2], "Hamm HD 12 VV", "null", 2200, "2019", Colors.Yellow, 122),
                new Venicle(types[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200, "2020", Colors.Red, 109)
            };

            types[types.Length - 1].Tax = 1.3;
            double maxTax = types[0].Tax;
            double sumTax = 0;
            foreach (VenicleType item in types)
            {
                item.Display();
                if (item.Tax > maxTax)
                {
                    maxTax = item.Tax;
                }
                sumTax += item.Tax;
            }
            Console.WriteLine();
            Console.WriteLine($"Max Tax = {maxTax}");
            Console.WriteLine($"Average Tax = {sumTax/types.Length}");

            //output array with foreach and ToString()
            Console.WriteLine();
            foreach (VenicleType item in types)
            {
                Console.WriteLine(item.ToString());                
            }

            foreach (Venicle item in venicles)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Array.Sort(venicles);
            foreach (Venicle item in venicles)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class VenicleType
    {       
        public string Type { get; set; }

        public double Tax { get; set; }

        public VenicleType(string venType, double venTax) 
        { 
            Type = venType; 
            Tax = venTax; 
        }

        public VenicleType() { }

        public void Display() => Console.WriteLine($"Venicle type = {Type}, Tax = {Tax}");        

        public override string ToString() => $"{Type},{Tax}";       

    }

    enum Colors
    {
        White,
        Blue,
        Green,
        Gray,
        Yellow,
        Red
    }
    class Venicle : IComparable<Venicle>
    {
        public VenicleType Type { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public string Year { get; set; }
        public Colors Colors { get; set; }
        public int Tank { get; set; }

        public Venicle(VenicleType venicleType, string modelName, string registrationNumber, int weight, string year, Colors colors, int tank) 
        {
            Type = venicleType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            Year = year;
            Colors = colors;
            Tank = tank;
        }

        public Venicle() { }

        public double GetCalcTaxPerMounth()
        {
            double result = (Weight * 0.0013) + Type.Tax * 30 + 5;
            return result;
        }

        public override string ToString() => $"{Type}, {ModelName}, {RegistrationNumber}, {Weight}, {Year}, {Colors}, {Tank}, {GetCalcTaxPerMounth().ToString("0.00")}";

        public int CompareTo(Venicle secondVenicle)
        {
            if (GetCalcTaxPerMounth() < secondVenicle.GetCalcTaxPerMounth())
            {
                return -1;
            }
            if (GetCalcTaxPerMounth() == secondVenicle.GetCalcTaxPerMounth())
            {
                return 0;
            }

            return 1;
        }
    }
}
