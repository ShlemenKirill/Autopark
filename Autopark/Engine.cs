
namespace Autopark
{
    class Engine
    {
        public string EngineName { get; set; }
        public double TaxEngineType { get; set; }

        public Engine(string engineName, double taxEngyneType) 
        {
            EngineName = engineName;
            TaxEngineType = taxEngyneType;
        }
        
    }

    class ElectricalEngine : Engine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;    
        }
    }

    class CombustionEngine : Engine
    {
        public double EngineCapacity { get; set; }
        public double FuelConsumption { get; set; }

        public CombustionEngine(string typeName, double taxCoefficient) :base(typeName, taxCoefficient)
        { 
            
        }
    }

    class GasolineEngine : CombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumption) : base("Gasoline", 1)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }
    }

    class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumption) : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }
    }
}
