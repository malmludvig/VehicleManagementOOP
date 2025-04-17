using System;
using System.Collections.Generic;
using OOPDemo.Interfaces;

namespace OOPDemo.Classes
{
    public class VehicleFleet
    {
        private List<Vehicle> vehicles;

        public VehicleFleet()
        {
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} har lagts till i fordonsflottan.");
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            if (vehicles.Remove(vehicle))
            {
                Console.WriteLine($"{vehicle.Make} {vehicle.Model} har tagits bort från fordonsflottan.");
            }
            else
            {
                Console.WriteLine("Fordonet hittades inte i fordonsflottan.");
            }
        }

        public void DisplayAllVehicles()
        {
            Console.WriteLine("=== Fordonsflotta ===");
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }

        public void RefuelAllVehicles()
        {
            Console.WriteLine("=== Tankar alla fordon ===");
            foreach (var vehicle in vehicles)
            {
                vehicle.Refuel();
            }
        }

        public void ChargeAllElectricVehicles()
        {
            Console.WriteLine("=== Laddar alla elbilar ===");
            var electricVehicles = vehicles.FindAll(v => v is Car car && car.IsElectric);
            if (electricVehicles.Count == 0)
            {
                Console.WriteLine("Inga elbilar hittades i fordonsflottan.");
                return;
            }

            foreach (var vehicle in electricVehicles)
            {
                ((Car)vehicle).ChargeBattery();
            }
        }

        public void DriveAllVehicles(double distance)
        {
            Console.WriteLine($"=== Kör alla fordon {distance:F1} mil ===");
            foreach (var vehicle in vehicles)
            {
                vehicle.Drive(distance);
            }
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public int GetVehicleCount()
        {
            return vehicles.Count;
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var vehicle in vehicles)
            {
                totalWeight += vehicle.Weight;
            }
            return totalWeight;
        }

        public void ServiceAllVehicles()
        {
            Console.WriteLine("=== Servar alla fordon ===");
            foreach (var vehicle in vehicles)
            {
                vehicle.Service();
            }
        }
    }
} 