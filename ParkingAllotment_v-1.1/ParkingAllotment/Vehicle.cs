using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class Vehicle
    {
        private VehicleType vehicleType { get; set; }
        private string VehicleNumber { get; set; }

        public Vehicle(VehicleType vehicleType, string vehicleNumber)
        {
            this.vehicleType = vehicleType;
            this.VehicleNumber = vehicleNumber;
        }

        public VehicleType GetVehicleType()
        {
            return vehicleType;
        }

        public string GetVehicleNumber()
        {
            return VehicleNumber;
        }
    }
}