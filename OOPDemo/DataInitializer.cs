using System;
using System.Collections.Generic;
using OOPDemo.Classes;
using OOPDemo.Interfaces;

namespace OOPDemo
{
    public static class DataInitializer
    {
        public static (List<VehicleOwner> owners, List<Vehicle> vehicles) InitializeData()
        {
            var owners = new List<VehicleOwner>
            {
                new VehicleOwner("Anna Andersson", "Storgatan 1", "070-1234567"),
                new VehicleOwner("Bengt Bengtsson", "Lillgatan 2", "070-7654321")
            };

            var vehicles = new List<Vehicle>
            {
                new Car("Volvo", "XC90", 2022, "Svart", 2100, true, 5, true, "Automat", false),
                new Car("Tesla", "Model 3", 2023, "Vit", 1800, true, 4, false, "Automat", true),
                new Car("BMW", "M5", 2021, "Blå", 1900, false, 4, true, "Manuell", false),
                new Truck("Scania", "R500", 2020, "Röd", 8000, true, true, 40, "E4"),
                new Truck("Volvo", "FH16", 2021, "Vit", 7500, false, false, 30, "E6")
            };

            // Koppla fordon till ägare
            ((VehicleOwner)owners[0]).AddVehicle(vehicles[0]);
            ((VehicleOwner)owners[0]).AddVehicle(vehicles[3]);
            ((VehicleOwner)owners[1]).AddVehicle(vehicles[1]);
            ((VehicleOwner)owners[1]).AddVehicle(vehicles[4]);

            return (owners, vehicles);
        }
    }
} 