using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {        

            VenicleType[] array = new VenicleType[] 
            { new VenicleType("Bus", 1.2), 
              new VenicleType("Car", 1), 
              new VenicleType("Rink", 1.5), 
              new VenicleType("Tractor", 1.2) };

            array[array.Length - 1].Tax = 1.3;
            double maxTax = array[0].Tax;
            double sumTax = 0;
            foreach (VenicleType item in array)
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
            Console.WriteLine($"Average Tax = {sumTax/array.Length}");

            //output array with foreach and ToString()
            Console.WriteLine();
            foreach (VenicleType item in array)
            {
                Console.WriteLine(item.ToString());                
            }
        }
    }

    class VenicleType
    {       
        public string Type { get; set; }

        public double Tax { get; set; }

        public VenicleType(string venType, double venTax) { Type = venType; Tax = venTax; }

        public void Display()
        {
            Console.WriteLine($"Venicle type = {Type}, Tax = {Tax}");
        }

        public override string ToString() => $"{Type},{Tax}";       

    }
}
