using System;

namespace Autopark
{
    class Garage
    {
        public Venicle[] venicles { get; set; }

        public void DriveIntoGarage()
        {
            Console.WriteLine("Drive into Garage");
            Console.WriteLine(new string('-', 20));
            Collections collections = new Collections(@"C:\Users\Кирилл\source\repos\Autopark\Autopark\types.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\venicles.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\rents.csv");
            for (int i = 0; i < collections.ListVenicle.Count; i++)
            {
                Push(collections.ListVenicle[i]);
                foreach (var item in venicles)
                {
                    Console.WriteLine($"Car {item.ModelName}, {item.RegistrationNumber} in Garage");
                }
                Console.WriteLine(new string('-', 20));
            }
            
        }

        public void DriveOutGarage()
        {
            Console.WriteLine("Drive out Garage");
            Console.WriteLine(new string('-', 20));            
            while (venicles.Length > 0)
            { 
                Pop();
                foreach (var item in venicles)
                {
                    Console.WriteLine($"Car {item.ModelName}, {item.RegistrationNumber} in Garage");
                }
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine("Garage is empty");
        }
        public void Push(Venicle venicle)
        {
            if (venicles == null)
            {
                Venicle[] tempArray = new Venicle[1];
                tempArray[0] = venicle;
                venicles = tempArray;
            }
            else
            {
                Venicle[] tempArray = new Venicle[venicles.Length + 1];
                for (int i = tempArray.Length - 1; i > 0; i--)
                {
                    tempArray[i] = venicles[i - 1];
                }
                tempArray[0] = venicle;
                venicles = tempArray;

            }
            
        }
        public void Pop()
        {
            Console.WriteLine($"Car {venicles[0].ModelName}, {venicles[0].RegistrationNumber} drive out Garage");
            venicles[0] = null;
            Venicle[] tempArray = new Venicle[venicles.Length - 1];
            for (int i = 0; i < venicles.Length - 1; i++)
            {
                tempArray[i] = venicles[i + 1];
            }
            venicles = tempArray;
        }
    }
}
