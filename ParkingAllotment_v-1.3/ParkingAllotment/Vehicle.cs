using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class Vehicle
    {
        public VehicleType vehicleType { get; private set; }
        public string VehicleNumber { get; private set; }

        public Vehicle(VehicleType vehicleType, string vehicleNumber)
        {
            this.vehicleType = vehicleType;
            this.VehicleNumber = vehicleNumber;
        }
    }
}