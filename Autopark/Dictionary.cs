using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Autopark
{
    class Dictionary
    {
        public string[] DetailList { get; set; }
        public Dictionary<string, int> DetailsDictionary { get; set; }

        public Dictionary() { }
        public Dictionary(string csvFile)
        {
            DetailList = LoadList(csvFile);
            CreateDictionary();
        }


        public string[] LoadList(string inFile)
        {
            string[] detailList = new string[] { };
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {                    
                    string line = sr.ReadToEnd().Replace("\r", "").Replace("\n", ";");                    
                    line = line.Remove(line.Length - 1);
                    detailList = line.Split(';');                    
                }
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"Error! File {inFile} is not found!");
            }
            return detailList;
        }
        
        public void CreateDictionary()
        {
            Dictionary<string, int> detailsDictionary = new Dictionary<string, int>();            
            
            for (int i = 0; i < DetailList.Length; i++)
            {
                bool IsExsist = false;
                int counter = 1;
                for (int j = i+1; j < DetailList.Length; j++)
                {
                    if (DetailList[i] == DetailList[j])
                    {
                        counter++;
                    }
                }

                foreach (var item in detailsDictionary)
                {
                    if (item.Key == DetailList[i])
                    {
                        IsExsist = true;
                        break;
                    }
                }

                if (!IsExsist)
                {
                    detailsDictionary.Add(DetailList[i], counter);
                }
            } 
            DetailsDictionary = detailsDictionary;
        }

        public void PrintDictionary()
        {
            foreach (var item in DetailsDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} шт.");
            }
        }
    }
}
