using System;

namespace OOPDemo.Classes
{
    // Klass för lastbilar
    public class Truck : Vehicle
    {
        public bool IsHeavyDuty { get; private set; }
        public int CargoCapacity { get; private set; }
        public string FavoriteRoute { get; private set; }

        public Truck(string make, string model, int year, string color, double weight, bool isServiced, bool isHeavyDuty, int cargoCapacity, string favoriteRoute)
            : base(make, model, year, color, weight, isServiced)
        {
            IsHeavyDuty = isHeavyDuty;
            CargoCapacity = cargoCapacity;
            FavoriteRoute = favoriteRoute;
            FuelConsumption = 1.2; // Lastbilar använder mer bensin per mil
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Tung transport: {(IsHeavyDuty ? "Ja" : "Nej")}");
            Console.WriteLine($"Lastkapacitet: {CargoCapacity} ton");
            Console.WriteLine($"Favoritrutt: {FavoriteRoute}");
        }
    }
}