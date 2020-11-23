using System;
using System.Linq;

namespace Autopark
{
    class CarWash
    {     
        public Venicle[] venicles { get; set; }
        
        public CarWash() { }
        public void WashCars()
        {
            Collections collections = new Collections(@"C:\Users\Кирилл\source\repos\Autopark\Autopark\types.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\venicles.csv", @"C:\Users\Кирилл\source\repos\Autopark\Autopark\rents.csv");
            for (int i = 0; i < collections.ListVenicle.Count(); i++)
            {
                Enqueue(collections.ListVenicle[i]);
            }            

            foreach (var item in venicles)
            {
                Console.WriteLine($"Car {item.ModelName} , {item.RegistrationNumber} in queue to car wash");
            }

            while (venicles.Length != 0)
            {                
                Dequeue();
                Console.WriteLine(new string('-', 20));
                foreach (var item in venicles)
                {
                    Console.WriteLine($"Car {item.ModelName}, {item.RegistrationNumber} in queue to car wash");
                }
                if (venicles.Length == 0)
                {
                    Console.WriteLine("No cars in queue to car wash!");
                }
            }
            

        }
        public void Enqueue(Venicle venicle)
        {
            if (venicles == null)
            {
                venicles = new Venicle[1] {venicle};
            }
            else
            {
                int lenght = venicles.Length + 1;
                Venicle[] newVenicle = new Venicle[lenght];
                Array.Copy(venicles, newVenicle, venicles.Length);
                newVenicle[newVenicle.Length - 1] = venicle;
                venicles = newVenicle;
            }       
        }

        public void Dequeue()
        { 
            Venicle[] temp = new Venicle[venicles.Length - 1];
            venicles[0] = null;            
            for (int i = 0; i < venicles.Length - 1; i++)
            {
                temp[i] = venicles[i + 1];
            }
            venicles = temp;            
        }
    }
}
