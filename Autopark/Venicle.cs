﻿using System;

namespace Autopark
{
    class Venicle : IComparable<Venicle>
    {
        public VenicleType Type { get; set; }
        public Engine Engine { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public string Year { get; set; }
        public Colors Colors { get; set; }
        public int Tank { get; set; }

        public Venicle(VenicleType venicleType, Engine engine, string modelName, string registrationNumber, int weight, string year, Colors colors, int tank)
        {
            Type = venicleType;
            Engine = engine;
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
            double result = (Weight * 0.0013) + Type.Tax * 30*Engine.TaxEngineType + 5;
            return result;
        }

        public override string ToString() => $"{Type}, {Engine.EngineName}, {ModelName}, {RegistrationNumber}, {Weight}, {Year}, {Colors}, {Tank}, {GetCalcTaxPerMounth().ToString("0.00")}";

        public int CompareTo(Venicle other)
        {
            if (GetCalcTaxPerMounth() < other.GetCalcTaxPerMounth())
            {
                return -1;
            }
            if (GetCalcTaxPerMounth() == other.GetCalcTaxPerMounth())
            {
                return 0;
            }

            return 1;
        }

        public override bool Equals(object obj)
        {
            Venicle venicle = (Venicle)obj;

            return (this.Type == venicle.Type) && (this.ModelName == venicle.ModelName);
        }

    }
}