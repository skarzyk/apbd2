using System;
using System.Collections.Generic;
using Cwiczenia2.ContainerManagement;

namespace Cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container1 = new Container(ContainerType.Liquid, 10000, false);
            Container container2 = new Container(ContainerType.Gas, 8000, true);
            Container container3 = new Container(ContainerType.Refrigerated, 12000, false);
            
            container3.SetProduct("Bananas");
            container3.Temperature = 14;
            
            try
            {
                container1.LoadCargo(9000);
                container2.LoadCargo(4000);
                container3.LoadCargo(10000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy ładowaniu kontenerów (1-3): " + ex.Message);
            }
            
            Ship ship1 = new Ship("Statek 1", 100, 40000, 20);
            ship1.AddContainer(container1);
            ship1.AddContainer(container2);
            ship1.AddContainer(container3);
            
            Container container4 = new Container(ContainerType.Refrigerated, 8000, false);
            container4.SetProduct("Fish");
            container4.Temperature = 2;

            Container container5 = new Container(ContainerType.Liquid, 5000, false);
            try
            {
                container4.LoadCargo(4000);
                container5.LoadCargo(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy ładowaniu container4/container5: " + ex.Message);
            }
            List<Container> additionalContainers = new List<Container> { container4, container5 };
            foreach (var c in additionalContainers)
            {
                ship1.AddContainer(c);
            }
            
            Console.WriteLine($"\nRozładowujemy kontener gazowy {container2.SerialNumber}:");
            double unloadedMass = container2.UnloadCargo();
            Console.WriteLine($"Rozładowano {unloadedMass} kg. Pozostało {container2.CurrentLoad} kg.");
            
            Console.WriteLine($"\nUsuwamy kontener {container4.SerialNumber} ze statku:");
            ship1.RemoveContainer(container4);
            
            Console.WriteLine("\n=== Informacje o statku 1 ===");
            ship1.PrintVehicleInfo();
            Console.WriteLine("\n=== Informacje o kontenerze 3 ===");
            Console.WriteLine(container3);
            
            Container replacement = new Container(ContainerType.Gas, 8000, false);
            try
            {
                replacement.LoadCargo(3500);  // OK
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy ładowaniu replacement: " + ex.Message);
            }
            Console.WriteLine("\nZastępujemy kontener gazowy container2 nowym kontenerem:");
            ship1.RemoveContainer(container2);
            ship1.AddContainer(replacement);
            
            Ship ship2 = new Ship("Statek 2", 50, 30000, 15);
            Console.WriteLine($"\nPrzenosimy kontener {container1.SerialNumber} ze statku 1 do statku 2:");
            ship1.RemoveContainer(container1);
            ship2.AddContainer(container1);

            Console.WriteLine("\n=== Informacje o statku 1 (po przeniesieniu) ===");
            ship1.PrintVehicleInfo();
            Console.WriteLine("\n=== Informacje o statku 2 ===");
            ship2.PrintVehicleInfo();
            
            Console.WriteLine("\nPróba przeładowania kontenera gazowego container2 powyżej limitu:");
            try
            {
                container2.LoadCargo(6000);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
            Console.WriteLine("\nPróba ładowania container3 (Refrigerated) z produktem 'Meat' - zbyt niska temperatura:");
            container3.SetProduct("Meat");
            container3.Temperature = 2;
            try
            {
                container3.LoadCargo(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("\nPróba przeładowania kontenera Gas powyżej 50%:");
            Container container7 = new Container(ContainerType.Gas, 8000, true);
            try
            {
                container7.LoadCargo(5000);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
