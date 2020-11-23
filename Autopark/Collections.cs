using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Autopark
{
    class Collections
    {
        public List<VenicleType> ListVenicleType { get; set; }
        public List<Venicle> ListVenicle { get; set; }

        public Collections() { }
        public Collections(string types, string venicles, string rents)
        {
            ListVenicleType = LoadTypes(types);
            ListVenicle = LoadVenicles(venicles);
            LoadRents(rents);
        }

        public List<VenicleType> LoadTypes(string inFile)
        {
            List<VenicleType> listVenicleType = new List<VenicleType>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listVenicleType.Add(CreateType(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"Error! File {inFile} is not found!");
            }
            
            return listVenicleType;
        }
        public List<Venicle> LoadVenicles(string inFile)
        {
            List<Venicle> listVenicle = new List<Venicle>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listVenicle.Add(CreateVenicle(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"Error! File {inFile} is not found!");
            }

            return listVenicle;
        }
        public void LoadRents(string inFile)
        {
            
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] field = line.Split(';');
                        foreach (var item in ListVenicle)
                        {
                            if (item.Id == int.Parse(field[0]))
                            {
                                item.ListRent.Add(new Rent(DateTime.Parse(field[1]), double.Parse(field[2])));
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"Error! File {inFile} is not found!");
            }
        }
        public VenicleType CreateType(string csvString)
        {
            string[] line = csvString.Split(';');
            return new VenicleType(int.Parse(line[0]), double.Parse(line[2]) , line[1]);
        }
        public Venicle CreateVenicle(string csvString)
        {
            string[] line = csvString.Split(';');
            int id = int.Parse(line[0]);
            string modelname = line[2];
            string regostrationNumber = line[3];
            int weight = int.Parse(line[4]);
            string year = line[5];
            int mileage = int.Parse(line[6]);
            int tank = int.Parse(line[11]);
            Colors color = (Colors)Enum.Parse(typeof(Colors), line[7]);
            List<VenicleType> types = LoadTypes(@"C:\Users\Кирилл\source\repos\Autopark\Autopark\types.csv");
            VenicleType venicleType = null;
            foreach (var item in types)
            {                
                if (item.Id == int.Parse(line[1]))
                {
                    venicleType = new VenicleType(item.Id, item.Tax, item.Type);
                }
            }
            
            AbstractEngine engine = null;
            if (line[8] == "Gasoline")
            {
                engine = new GasolineEngine(double.Parse(line[9]),double.Parse(line[10]));
            }
            else if (line[8] == "Diesel")
            {
                engine = new DieselEngine(double.Parse(line[9]), double.Parse(line[10]));
            }
            else if (line[8] == "Electrical")
            {
                engine = new ElectricalEngine(double.Parse(line[10]));
            }
            return new Venicle(id, venicleType, engine, modelname, regostrationNumber, weight, year, color, mileage, tank, new List<Rent>());

        }
        public void Insert(int index, Venicle v)
        {
            ListVenicle.Insert(index, v);
        }
        public int Delete(int index)
        {
            if (index > ListVenicle.Count() || index < 0)
            {
                return -1;
            }

            ListVenicle.RemoveAt(index);
            return index;
        }
        public double SumTotalProfit()
        {
            double totalProfit = 0.0;
            foreach (var item in ListVenicle)
            {
                totalProfit += item.GetTotalProfit();
            }
            return totalProfit;
        }
        public void Print()
        {
            Console.WriteLine(string.Format("{0, -5}{1, -10}{2, -25}{3, -15}{4, -15}{5, -10}{6, -10}{7, -10}{8, -10}{9, -10}{10, -10}",
                    "Id",
                    "Type",
                    "ModelName",
                    "Number",
                    "Weight (kg)",
                    "Year",
                    "Mileage",
                    "Color",
                    "Income",
                    "Tax",
                    "Profit"));
            foreach (var item in ListVenicle)
            {
                Console.WriteLine(string.Format("{0, -5}{1, -10}{2, -25}{3, -15}{4, -15}{5, -10}{6, -10}{7, -10}{8, -10}{9, -10}{10, -10}", 
                    item.Id,
                    item.Type.Type,
                    item.ModelName,
                    item.RegistrationNumber,
                    item.Weight,
                    item.Year,
                    item.Mileage,
                    item.Colors,
                    item.GetTotalIncome().ToString("0.00"),
                    item.GetCalcTaxPerMounth().ToString("0.00"),
                    item.GetTotalProfit().ToString("0.00")));
            }
            Console.WriteLine(string.Format("{0, -120}{1, -10}", "Total", SumTotalProfit().ToString("0.00")));
            
            
        }
        public void Sort(IComparer<Venicle> comparator)
        {            
            for (int i = 0; i < ListVenicle.Count(); i++)
            {
                for (int j = 1; j < ListVenicle.Count() -1; j++)
                {
                    if (comparator.Compare(ListVenicle[i], ListVenicle[j]) == 1)
                    {
                        var temp = ListVenicle[i];
                        ListVenicle[i] = ListVenicle[j];
                        ListVenicle[j] = temp;
                    }
                    
                }
            }
        }
    }   
}
