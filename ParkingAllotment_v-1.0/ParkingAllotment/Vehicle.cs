using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class Vehicle
    {
        private VehicleType NumberOfWheel { get; set; }
        private string VehicleNumber { get; set; }

        public Vehicle(VehicleType vehicleType, string vehicleNumber)
        {
            this.NumberOfWheel = vehicleType;
            this.VehicleNumber = vehicleNumber;
        }

        public VehicleType GetNumberOfWheels()
        {
            return NumberOfWheel;
        }

        public string GetVehicleNumber()
        {
            return VehicleNumber;
        }
    }
}