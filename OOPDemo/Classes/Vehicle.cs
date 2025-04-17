using System;
using OOPDemo.Interfaces;

namespace OOPDemo.Classes
{
    // Basklass för fordon
    public abstract class Vehicle
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; }
        public double Weight { get; private set; }
        public bool IsServiced { get; set; }
        public int FuelLevel { get; private set; }
        public double FuelConsumption { get; protected set; } // Bensinförbrukning per mil

        public Vehicle(string make, string model, int year, string color, double weight, bool isServiced)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Weight = weight;
            IsServiced = isServiced;
            FuelLevel = 50; // Medel bränslenivå
            FuelConsumption = 0.5; // Standard bensinförbrukning per mil
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Märke: {Make}");
            Console.WriteLine($"Modell: {Model}");
            Console.WriteLine($"Årsmodell: {Year}");
            Console.WriteLine($"Färg: {Color}");
            Console.WriteLine($"Vikt: {Weight:F2} kg");
            Console.WriteLine($"Serviced: {(IsServiced ? "Ja" : "Nej")}");
            Console.WriteLine($"Bränslenivå: {FuelLevel}/100");
            Console.WriteLine($"Bensinförbrukning: {FuelConsumption:F2} liter/mil");
        }

        public virtual void Refuel()
        {
            double fuelAmount = Weight * 0.1; // Beräkna bränslemängd baserat på vikt
            FuelLevel = 100; // Sätt bränslenivån till 100
            Console.WriteLine($"{Make} {Model} har tankats till 100%");
        }

        public virtual bool Drive(double distance)
        {
            if (FuelLevel <= 0)
            {
                Console.WriteLine($"{Make} {Model} har slut på bensin och kan inte köra!");
                return false;
            }

            double fuelUsed = distance * FuelConsumption;
            if (fuelUsed > FuelLevel)
            {
                Console.WriteLine($"{Make} {Model} har inte tillräckligt med bensin för att köra {distance:F1} mil!");
                return false;
            }

            FuelLevel -= (int)fuelUsed;
            Console.WriteLine($"{Make} {Model} körde {distance:F1} mil och använde {fuelUsed:F2} liter bensin.");
            Console.WriteLine($"Ny bränslenivå: {FuelLevel}/100");
            return true;
        }

        public void Service()
        {
            IsServiced = true;
            Console.WriteLine($"{Make} {Model} har blivit servad.");
        }

    }
}