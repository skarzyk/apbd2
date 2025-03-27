namespace Cwiczenia2.ContainerManagement;

public class Truck : TransportVehicle
{
    public string LicensePlate { get; set; }

    public Truck(string name, int maxContainerCount, double maxWeightCapacity, string licensePlate)
        : base(name, maxContainerCount, maxWeightCapacity)
    {
        LicensePlate = licensePlate;
    }

    public override void PrintVehicleInfo()
    {
        System.Console.WriteLine($"Ciężarówka: {Name} (Nr rejestracyjny: {LicensePlate})");
        System.Console.WriteLine($"Kontenery: {Containers.Count} / {MaxContainerCount} | Limit wagowy: {MaxWeightCapacity}kg");
        foreach (var container in Containers)
        {
            System.Console.WriteLine(container);
        }
    }
}