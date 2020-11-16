
namespace Autopark
{
    abstract class AbstractEngine
    {
        public string EngineName { get; set; }
        public double TaxEngineType { get; set; }

        public AbstractEngine(string engineName, double taxEngyneType) 
        {
            EngineName = engineName;
            TaxEngineType = taxEngyneType;
        }

        public abstract double GetMaxKilometers(double fuelTank);
        
    }

    class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;    
        }
    }

    abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineCapacity { get; set; }
        public double FuelConsumption { get; set; }

        public AbstractCombustionEngine(string typeName, double taxCoefficient) :base(typeName, taxCoefficient)
        { 
            
        }
        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity / FuelConsumption * 100;
        }
    }

    class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumption) : base("Gasoline", 1)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }
    }

    class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumption) : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }
    }
}
