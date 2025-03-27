using System;
using System.Collections.Generic;

namespace Cwiczenia2.ContainerManagement
{
    public class Ship : TransportVehicle
    {
        public double MaxSpeed { get; set; }

        public Ship(string name, int maxContainerCount, double maxWeightCapacity, double maxSpeed)
            : base(name, maxContainerCount, maxWeightCapacity)
        {
            MaxSpeed = maxSpeed;
        }

        public override void PrintVehicleInfo()
        {
            System.Console.WriteLine($"Statek: {Name} (Prędkość: {MaxSpeed} węzłów)");
            System.Console.WriteLine($"Kontenery: {Containers.Count} / {MaxContainerCount} | Limit wagowy: {MaxWeightCapacity}kg");
            foreach (var container in Containers)
            {
                System.Console.WriteLine(container);
            }
        }
    }
}