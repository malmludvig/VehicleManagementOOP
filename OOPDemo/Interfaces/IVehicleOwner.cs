using System;
using OOPDemo.Classes;

namespace OOPDemo.Interfaces
{
    public interface IVehicleOwner
    {
        void AddVehicle(Vehicle vehicle);
        void ServiceAllVehicles();
        void DisplayAllVehicleInfo();
        void RefuelAllVehicles();
        bool DriveAllVehicles(double distance);
    }
}