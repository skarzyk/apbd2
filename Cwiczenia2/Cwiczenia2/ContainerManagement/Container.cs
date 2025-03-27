namespace Cwiczenia2.ContainerManagement
{
    public class Container : IHazardNotifier
    {
        public string SerialNumber { get; set; }
        public ContainerType Type { get; set; }
        public double MaxCapacity { get; set; }

        public double CurrentLoad { get; set; }
        
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public string Product { get; set; }
        public bool IsDangerous { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public double OwnWeight { get; set; }
        public double TotalWeight => OwnWeight + CurrentLoad;
        
        public Container(ContainerType type, double maxCapacity, bool isDangerous)
        {
            Type = type;
            MaxCapacity = maxCapacity;
            IsDangerous = isDangerous;
            CurrentLoad = 0;
            SerialNumber = GenerateSerialNumber(type.ToString());
        }
        
        public void LoadCargo(double mass)
        {
            double limit = IsDangerous ? 0.5 * MaxCapacity : 0.9 * MaxCapacity;
            if (mass > limit)
            {
                NotifyHazard($"Próba załadowania {mass}kg przekracza limit {limit}kg.");
                throw new OverfillException($"Przekroczono limit ładowania dla kontenera {SerialNumber}.");
            }
            if (Type == ContainerType.Refrigerated && Temperature < RequiredTemperature)
            {
                NotifyHazard($"Temperatura ({Temperature}C) jest niższa niż wymagana ({RequiredTemperature}C).");
                throw new Exception($"Błąd temperatury w kontenerze {SerialNumber}.");
            }

            CurrentLoad = mass;
            Console.WriteLine($"Ładunek {mass}kg został załadowany do kontenera {SerialNumber}.");
        }
        
        public double UnloadCargo() {
            double unloadedMass;
            if (this.Type == ContainerType.Gas) {
                unloadedMass = CurrentLoad * 0.95;
                CurrentLoad *= 0.05;
            } else {
                unloadedMass = CurrentLoad;
                CurrentLoad = 0;
            }
            return unloadedMass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"ALERT {SerialNumber}: {message}");
        }

        private static Dictionary<string, int> counter = new Dictionary<string, int>();

        public static string GenerateSerialNumber(string type)
        {
            if (!counter.ContainsKey(type))
            {
                counter[type] = 1;
            }
            else
            {
                counter[type]++;
            }

            return $"KON-{type}-{counter[type]}";
        }

        public void SetProduct(string product)
        {
            if (Type != ContainerType.Refrigerated)
            {
                Console.WriteLine("Tylko kontenery chłodnicze mogą mieć przypisany rodzaj produktu.");
                return;
            }
            
            if (!ProductTemperatures.ContainsKey(product))
            {
                Console.WriteLine($"Produkt '{product}' nie jest obsługiwany przez mapę temperatur.");
                return;
            }

            Product = product;
            Console.WriteLine($"Ustawiono produkt '{product}' w kontenerze {SerialNumber}.");
        }

        public static Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", 4 },
            { "Ice cream", -18 },
            { "Frozen pizza", -8 },
            { "Cheese", 7 },
            { "Sausages", 2 },
            { "Eggs", 5 }
        };

        private double RequiredTemperature
        {
            get
            {
                if (Product != null && ProductTemperatures.ContainsKey(Product))
                {
                    return ProductTemperatures[Product];
                }

                return 0;
            }
        }

        public override string ToString()
        {
            string info = $"Kontener {SerialNumber} ({Type}): {CurrentLoad}kg / {MaxCapacity}kg";
            if (Type == ContainerType.Refrigerated && Product != null)
            {
                info += $", Produkt: {Product} wymaga {RequiredTemperature}C, aktualna temperaturta: {Temperature}C";
            }

            return info;
        }
    }
}