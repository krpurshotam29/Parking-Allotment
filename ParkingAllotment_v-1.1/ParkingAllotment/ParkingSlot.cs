using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class ParkingSlot
    {
        private List<Vehicle> vehicleList;

        public ParkingSlot()
        {
            this.vehicleList = new List<Vehicle>();
        }

        public int GetNumberOfTwoWheelerParked()
        {
            IEnumerable<Vehicle> numberOfTwoWheelerParked = from vehicle in vehicleList where vehicle.GetVehicleType() == VehicleType.TWO_WHEELER select vehicle;
            return numberOfTwoWheelerParked.Count();
        }

        public int GetNumberOfFourWheelerParked()
        {
            IEnumerable<Vehicle> numberOfFourWheelerParked = from vehicle in vehicleList where vehicle.GetVehicleType() == VehicleType.FOUR_WHEELER select vehicle;
            return numberOfFourWheelerParked.Count();
        }

        public int GetNumberOfOtherVehicleParked()
        {
            IEnumerable<Vehicle> numberOfOtherVehicleParked = from vehicle in vehicleList where vehicle.GetVehicleType() == VehicleType.OTHER select vehicle;
            return numberOfOtherVehicleParked.Count();
        }

        public List<Vehicle> GetVehicleList()
        {
            return vehicleList;
        }

        public void ParkVehicle(VehicleType vehicleType, string vehicleNumber)
        {
            Vehicle vehicle = new Vehicle(vehicleType, vehicleNumber);
            vehicleList.Add(vehicle);
        }

        public void UnParkVehicle(VehicleType vehicleType, string vehicleNumber)
        {
            Vehicle currentVehicle = new Vehicle(vehicleType, vehicleNumber);
            vehicleList.Remove(currentVehicle);
        }
    }
}