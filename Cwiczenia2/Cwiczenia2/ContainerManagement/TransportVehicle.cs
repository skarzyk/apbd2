namespace Cwiczenia2.ContainerManagement;

public abstract class TransportVehicle
{
    public string Name { get; set; }
    public List<Container> Containers { get; } = new List<Container>();
    public int MaxContainerCount { get; set; }
    public double MaxWeightCapacity { get; set; }

    protected TransportVehicle(string name, int maxContainerCount, double maxWeightCapacity)
    {
        Name = name;
        MaxContainerCount = maxContainerCount;
        MaxWeightCapacity = maxWeightCapacity;
    }

    public bool AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            Console.WriteLine("Nie można dodać kontenera: osiągnięto maksymalną liczbę.");
            return false;
        }
        double currentTotal = Containers.Sum(c => c.TotalWeight);
        if (currentTotal + container.TotalWeight > MaxWeightCapacity)
        {
            Console.WriteLine("Nie można dodać kontenera: łączna waga przekroczy limit pojazdu.");
            return false;
        }
        Containers.Add(container);
        Console.WriteLine($"Kontener {container.SerialNumber} został dodany do pojazdu {Name}.");
        return true;
    }

    public bool RemoveContainer(Container container)
    {
        if (Containers.Remove(container))
        {
            Console.WriteLine($"Kontener {container.SerialNumber} został usunięty z pojazdu {Name}.");
            return true;
        }
        else
        {
            Console.WriteLine("Kontener nie został znaleziony.");
            return false;
        }
    }

    public double CurrentTotalWeight()
    {
        return Containers.Sum(c => c.TotalWeight);
    }

    public abstract void PrintVehicleInfo();
}