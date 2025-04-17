using System;
using System.Collections.Generic;
using OOPDemo.Interfaces;

namespace OOPDemo.Classes
{
    // Klass för fordonsägare
    public class VehicleOwner : IVehicleOwner
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        private List<Vehicle> vehicles;

        public VehicleOwner(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"{vehicle.Model} har lagts till i {Name}s garage.");
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public void ServiceAllVehicles()
        {
            Console.WriteLine($"\nServar alla fordon för {Name}:");
            foreach (var vehicle in vehicles)
            {
                vehicle.Service();
            }
        }

        public void DisplayAllVehicleInfo()
        {
            Console.WriteLine($"\nÄgare: {Name}");
            Console.WriteLine($"Adress: {Address}");
            Console.WriteLine($"Telefon: {PhoneNumber}");
            Console.WriteLine("Fordon:");
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }

        public void RefuelAllVehicles()
        {
            Console.WriteLine($"\nTankar alla fordon för {Name}:");
            foreach (var vehicle in vehicles)
            {
                vehicle.Refuel();
            }
        }

        public bool DriveAllVehicles(double distance)
        {
            Console.WriteLine($"\n{Name} tar alla fordon på en åktur:");
            bool allVehiclesDrove = true;
            foreach (var vehicle in vehicles)
            {
                if (!vehicle.Drive(distance))
                {
                    allVehiclesDrove = false;
                }
            }
            return allVehiclesDrove;
        }
    }
}