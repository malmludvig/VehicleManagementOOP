using System;
using OOPDemo.Interfaces;

namespace OOPDemo.Classes
{
    // Klass för personbilar
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; private set; }
        public bool HasSunroof { get; private set; }
        public string TransmissionType { get; private set; }
        public bool IsElectric { get; private set; }
        public int BatteryLevel { get; private set; }

        public Car(string make, string model, int year, string color, double weight, bool isServiced,
                  int numberOfDoors, bool hasSunroof, string transmissionType, bool isElectric)
            : base(make, model, year, color, weight, isServiced)
        {
            NumberOfDoors = numberOfDoors;
            HasSunroof = hasSunroof;
            TransmissionType = transmissionType;
            IsElectric = isElectric;
            BatteryLevel = 100;
        }


        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Antal dörrar: {NumberOfDoors}");
            Console.WriteLine($"Har soltak: {(HasSunroof ? "Ja" : "Nej")}");
            Console.WriteLine($"Växellåda: {TransmissionType}");
            Console.WriteLine($"Elbil: {(IsElectric ? "Ja" : "Nej")}");
            if (IsElectric)
            {
                Console.WriteLine($"Batterinivå: {BatteryLevel}%");
            }
        }

        public override void Refuel()
        {
            if (IsElectric)
            {
                Console.WriteLine($"{Make} {Model} är en elbil och kan inte tankas med bensin!");
                return;
            }
            base.Refuel();
        }

        public void ChargeBattery()
        {
            if (!IsElectric)
            {
                Console.WriteLine($"{Make} {Model} är inte en elbil och kan inte laddas!");
                return;
            }
            BatteryLevel = 100;
            Console.WriteLine($"{Make} {Model} har laddats till 100%");
        }

        public override bool Drive(double distance)
        {
            if (IsElectric)
            {
                double batteryUsed = distance * 2; // 2% batteri per mil
                if (batteryUsed > BatteryLevel)
                {
                    Console.WriteLine($"{Make} {Model} har inte tillräckligt med batteri för att köra {distance:F1} mil!");
                    return false;
                }
                BatteryLevel -= (int)batteryUsed;
                Console.WriteLine($"{Make} {Model} körde {distance:F1} mil och använde {batteryUsed:F2}% batteri.");
                Console.WriteLine($"Ny batterinivå: {BatteryLevel}%");
                return true;
            }
            return base.Drive(distance);
        }
    }
}