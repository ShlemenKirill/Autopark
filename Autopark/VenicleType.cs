using System;

namespace Autopark
{
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
}
