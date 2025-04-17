using OOPDemo.Classes;
using OOPDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace OOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OOP Demo - Fordonshantering");

            // Steg 1: Hämta initial data från DataInitializer
            var initializedData = DataInitializer.InitializeData();
            
            // Steg 2: Dela upp datan i två separata listor
            List<VehicleOwner> owners = initializedData.owners;
            List<Vehicle> vehicles = initializedData.vehicles;
            
            // Steg 3: Skapa en ny fordonsflotta
            var fleet = new VehicleFleet();
            
            // Steg 4: Lägg till alla fordon i flottan
            foreach (var vehicle in vehicles)
            {
                fleet.AddVehicle(vehicle);
            }

            // Starta meny-navigeringen
            RunMenu(fleet, owners);
        }

        static void RunMenu(VehicleFleet fleet, List<VehicleOwner> owners)
        {
            bool speletKörs = true;
            while (speletKörs)
            {
                Console.Clear();
                Console.WriteLine("=== Fordonshanteringssystem ===");
                Console.WriteLine("1. Visa alla fordon");
                Console.WriteLine("2. Visa alla ägare och deras fordon");
                Console.WriteLine("3. Tanka ett specifikt fordon");
                Console.WriteLine("4. Tanka alla fordon");
                Console.WriteLine("5. Ladda elbil");
                Console.WriteLine("6. Ladda alla elbilar");
                Console.WriteLine("7. Kör fordon");
                Console.WriteLine("8. Visa fordonsflottans statistik");
                Console.WriteLine("9. Avsluta");
                Console.Write("Välj ett alternativ: ");

                var key = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (key)
                {
                    case '1':
                        fleet.DisplayAllVehicles();
                        break;
                    case '2':
                        DisplayOwnersAndVehicles(owners);
                        break;
                    case '3':
                        RefuelSpecificVehicle(fleet.GetVehicles());
                        break;
                    case '4':
                        fleet.RefuelAllVehicles();
                        break;
                    case '5':
                        ChargeElectricVehicle(fleet.GetVehicles());
                        break;
                    case '6':
                        fleet.ChargeAllElectricVehicles();
                        break;
                    case '7':
                        DriveVehicle(fleet.GetVehicles());
                        break;
                    case '8':
                        DisplayFleetStatistics(fleet);
                        break;
                    case '9':
                        speletKörs = false;
                        Console.WriteLine("Tack för att du spelade!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
                if (key != '9')
                {
                    Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayOwnersAndVehicles(List<VehicleOwner> owners)
        {
            Console.WriteLine("=== Ägare och Deras Fordon ===");
            foreach (var owner in owners)
            {
                Console.WriteLine($"\nÄgare: {owner.Name}");
                Console.WriteLine($"Adress: {owner.Address}");
                Console.WriteLine($"Telefon: {owner.PhoneNumber}");
                Console.WriteLine("Fordon:");
                foreach (var vehicle in owner.GetVehicles())
                {
                    vehicle.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }

        static void RefuelSpecificVehicle(List<Vehicle> vehicles)
        {
            Console.WriteLine("Välj ett fordon att tanka:");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vehicles[i].Make} {vehicles[i].Model}");
            }

            var key = Console.ReadKey().KeyChar;
            if (char.IsDigit(key) && int.TryParse(key.ToString(), out int choice) && choice > 0 && choice <= vehicles.Count)
            {
                vehicles[choice - 1].Refuel();
            }
            else
            {
                Console.WriteLine("\nOgiltigt val.");
            }
        }

        static void ChargeElectricVehicle(List<Vehicle> vehicles)
        {
            var electricVehicles = vehicles.FindAll(v => v is Car car && car.IsElectric);
            if (electricVehicles.Count == 0)
            {
                Console.WriteLine("Inga elbilar hittades.");
                return;
            }

            Console.WriteLine("Välj en elbil att ladda:");
            for (int i = 0; i < electricVehicles.Count; i++)
            {
                var car = (Car)electricVehicles[i];
                Console.WriteLine($"{i + 1}. {car.Make} {car.Model}");
            }

            var key = Console.ReadKey().KeyChar;
            if (char.IsDigit(key) && int.TryParse(key.ToString(), out int choice) && choice > 0 && choice <= electricVehicles.Count)
            {
                ((Car)electricVehicles[choice - 1]).ChargeBattery();
            }
            else
            {
                Console.WriteLine("\nOgiltigt val.");
            }
        }

        static void DriveVehicle(List<Vehicle> vehicles)
        {
            Console.WriteLine("Välj ett fordon att köra:");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vehicles[i].Make} {vehicles[i].Model}");
            }

            var key = Console.ReadKey().KeyChar;
            if (char.IsDigit(key) && int.TryParse(key.ToString(), out int choice) && choice > 0 && choice <= vehicles.Count)
            {
                Console.Write("\nAnge distans att köra (mil): ");
                if (double.TryParse(Console.ReadLine(), out double distance))
                {
                    vehicles[choice - 1].Drive(distance);
                }
                else
                {
                    Console.WriteLine("Ogiltig distans.");
                }
            }
            else
            {
                Console.WriteLine("\nOgiltigt val.");
            }
        }

        static void DisplayFleetStatistics(VehicleFleet fleet)
        {
            Console.WriteLine("=== Fordonsflottans Statistik ===");
            Console.WriteLine($"Antal fordon: {fleet.GetVehicleCount()}");
            Console.WriteLine($"Total vikt: {fleet.GetTotalWeight():F2} kg");
            
            var electricVehicles = fleet.GetVehicles().FindAll(v => v is Car car && car.IsElectric);
            Console.WriteLine($"Antal elbilar: {electricVehicles.Count}");
            
            var trucks = fleet.GetVehicles().FindAll(v => v is Truck);
            Console.WriteLine($"Antal lastbilar: {trucks.Count}");
        }
    }
}
