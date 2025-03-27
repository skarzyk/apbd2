namespace Cwiczenia2.ContainerManagement;

public class Train : TransportVehicle
{
    public int CarsCount { get; set; }

    public Train(string name, int maxContainerCount, double maxWeightCapacity, int carsCount)
        : base(name, maxContainerCount, maxWeightCapacity)
    {
        CarsCount = carsCount;
    }

    public override void PrintVehicleInfo()
    {
        System.Console.WriteLine($"Pociąg: {Name} (Wagonów: {CarsCount})");
        System.Console.WriteLine($"Kontenery: {Containers.Count} / {MaxContainerCount} | Limit wagowy: {MaxWeightCapacity}kg");
        foreach (var container in Containers)
        {
            System.Console.WriteLine(container);
        }
    }
}