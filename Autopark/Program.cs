using System;
using System.Collections.Generic;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {            
            //VenicleType[] types = new VenicleType[] 
            //{ 
            //    new VenicleType(1, 1.2,"Bus"), 
            //    new VenicleType(2, 1, "Car"), 
            //    new VenicleType(3, 1.5, "Rink"), 
            //    new VenicleType(4, 1.2,"Tractor") 
            //};

            //Venicle[] venicles = new Venicle[]
            //{
            //    new Venicle(1, types[0],new GasolineEngine(2, 8.1) , "Volkswagen Crafter", "5427 AX-7", 2022, "2015", Colors.Blue, 376000, 75),
            //    new Venicle(2, types[0],new GasolineEngine(2.18, 8.5), "Volkswagen Crafter", "6427 AA-7", 2500, "2014", Colors.White, 376000, 75),
            //    new Venicle(3, types[0],new ElectricalEngine(50), "Electric Bus E321", "6785 BA-7", 12080, "2019", Colors.Green, 20451, 150),
            //    new Venicle(4, types[1],new DieselEngine(1.6, 7.2), "Golf 5", "8682 AX-7", 1200, "2006", Colors.Gray, 230451, 55),
            //    new Venicle(5, types[1],new ElectricalEngine(25), "Tesla Model S 70D", "E001 AA-7", 2200, "2019", Colors.White, 10454, 70),
            //    new Venicle(6, types[2],new DieselEngine(3.2, 25), "Hamm HD 12 VV", null, 2200, "2019", Colors.Yellow, 122, 20),
            //    new Venicle(7, types[3],new DieselEngine(4.75, 20.1), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, "2020", Colors.Red, 109, 135)
            //};

            //types[types.Length - 1].Tax = 1.3;
            //double maxTax = types[0].Tax;
            //double sumTax = 0;
            //foreach (VenicleType item in types)
            //{
            //    item.Display();
            //    if (item.Tax > maxTax)
            //    {
            //        maxTax = item.Tax;
            //    }
            //    sumTax += item.Tax;
            //}
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine($"Max Tax = {maxTax}");
            //Console.WriteLine($"Average Tax = {sumTax/types.Length}");

            ////output array with foreach and ToString()
            //Console.WriteLine(new string('-',20));
            //foreach (VenicleType item in types)
            //{
            //    Console.WriteLine(item.ToString());                
            //}

            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine("Level 2");
            //Console.WriteLine(new string('-', 20));
            //foreach (Venicle item in venicles)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine();
            //Array.Sort(venicles);
            //foreach (Venicle item in venicles)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine("Level 3");
            //Console.WriteLine(new string('-', 20));
            ////output array with equal cars
            //for (int i = 0; i < venicles.Length; i++)
            //{
            //    for (int j = i+1; j < venicles.Length; j++)
            //    {
            //        if (i == j)
            //        {
            //            continue;
            //        }
            //        if (venicles[i].Equals(venicles[j]))
            //        {
            //            Console.WriteLine("These cars are equals:");
            //            Console.WriteLine(venicles[i]);
            //            Console.WriteLine(venicles[j]);
            //        }
            //    }
                
            //}

            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine("Level 4");
            //Console.WriteLine(new string('-', 20));

            //foreach (Venicle item in venicles)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            
            //double maxDistance = venicles[0].Engine.GetMaxKilometers(venicles[0].Tank);
            //int index = 0;
            //for (int i = 0; i < venicles.Length; i++)
            //{
            //    if (venicles[i].Engine.GetMaxKilometers(venicles[i].Tank) > maxDistance)
            //    {
            //        maxDistance = venicles[i].Engine.GetMaxKilometers(venicles[i].Tank);
            //        index = i;
            //    }
            //}
            //Console.WriteLine($"Max distance = {maxDistance.ToString("0.00")} kilometers");
            //Console.WriteLine($"Car that can travel the maximum distance: {venicles[index]}");

            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Level 5");
            Console.WriteLine(new string('-', 20));

            Collections collections = new Collections(@"C:\Users\Кирилл\source\repos\Autopark\Autopark\types.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\venicles.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\rents.csv");
            collections.Print();
            collections.ListVenicle.Add(new Venicle(8, new VenicleType(2, 43, "Car"), new GasolineEngine(2.0, 8.6), "BMW", "7777-IK7", 2220, "2020", Colors.Red, 9900, 45, new List<Rent>()));
            collections.Delete(1);
            collections.Delete(4);
            collections.Print();
            Comparer comparer = new Comparer();
            collections.Sort(comparer);
            collections.Print();

        }
    }        
}
