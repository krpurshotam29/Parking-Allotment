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
        private int TwoWheelerParkingAreaCapacity { get; set; }
        private int FourWheelerParkingAreaCapacity { get; set; }
        private int OtherVehicleParkingAreaCapacity { get; set; }
        private int TwoWheelerCount;
        private int FourWheelerCount;
        private int OtherVehicleCount;
        private int TotalParkingCapacity;
        private int TotalVehicleParked;

        public ParkingSlot(int twoWheelerCapacity, int fourWheelerCapacity, int otherVehicleCapacity)
        {
            this.vehicleList = new List<Vehicle>();
            this.TwoWheelerParkingAreaCapacity = twoWheelerCapacity;
            this.FourWheelerParkingAreaCapacity = fourWheelerCapacity;
            this.OtherVehicleParkingAreaCapacity = otherVehicleCapacity;
            this.TwoWheelerCount = 0;
            this.FourWheelerCount = 0;
            this.OtherVehicleCount = 0;
            this.TotalParkingCapacity = twoWheelerCapacity + fourWheelerCapacity + otherVehicleCapacity;
            this.TotalVehicleParked = 0;
        }

        public int GetEmptyTwoWheelerSlots()
        {
            int count=0;
            foreach(Vehicle vehicle in vehicleList){
                if(vehicle.GetNumberOfWheels==VehicleType.TWO_WHEELER)
                    count++;
            }
            return count;
        }

        public int GetEmptyFourWheelerSlots()
        {
            int count=0;
            foreach(Vehicle vehicle in vehicleList){
                if(vehicle.GetNumberOfWheels==VehicleType.FOUR_WHEELER)
                    count++;
            }
            return count;
        }

        public int GetEmptyOtherVehicleSlots()
        {
           int count=0;
            foreach(Vehicle vehicle in vehicleList){
                if(vehicle.GetNumberOfWheels==VehicleType.OTHER)
                    count++;
            }
            return count;
        }

        public List<Vehicle> GetVehicleList()
        {
            return vehicleList;
        }

        public bool ParkVehicle(VehicleType vehicleType, string vehicleNumber)
        {
            if (IsParkingSlotEmpty())
            {
                
                if (vehicleType == VehicleType.TWO_WHEELER && TwoWheelerCount < TwoWheelerParkingAreaCapacity)
                {
                    this.TotalVehicleParked += 1;
                    Vehicle vehicle = new Vehicle(vehicleType, vehicleNumber);
                    vehicleList.Add(vehicle);
                    TwoWheelerCount += 1;
                    return true;
                }   
                else if (vehicleType == VehicleType.FOUR_WHEELER && FourWheelerCount < FourWheelerParkingAreaCapacity)
                {
                    this.TotalVehicleParked += 1;
                    Vehicle vehicle = new Vehicle(vehicleType, vehicleNumber);
                    vehicleList.Add(vehicle);
                    FourWheelerCount += 1;
                    return true;
                }
                else if (vehicleType == VehicleType.OTHER && OtherVehicleCount < OtherVehicleParkingAreaCapacity)
                {
                    this.TotalVehicleParked += 1;
                    Vehicle vehicle = new Vehicle(vehicleType, vehicleNumber);
                    vehicleList.Add(vehicle);
                    OtherVehicleCount += 1;
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool UnParkVehicle(VehicleType vehicleType, string vehicleNumber)
        {
            Vehicle currentVehicle = new Vehicle(vehicleType, vehicleNumber);
            foreach (Vehicle vehicle in vehicleList)
            {
                //Console.WriteLine("Test ----" + (vehicle.Equals(currentVehicle)));
                if (vehicle.GetVehicleNumber()==vehicleNumber && vehicle.GetNumberOfWheels()==vehicleType)
                {
                    if (vehicleType == VehicleType.TWO_WHEELER && TwoWheelerCount > 0)
                    {
                        this.TotalVehicleParked -= 1;
                        vehicleList.Remove(vehicle);
                        TwoWheelerCount -= 1;
                        return true;
                    }  
                    else if (vehicleType == VehicleType.FOUR_WHEELER && FourWheelerCount > 0) {
                        this.TotalVehicleParked -= 1;
                        vehicleList.Remove(vehicle);
                        FourWheelerCount -= 1;
                        return true;
                    }    
                    else if (vehicleType == VehicleType.OTHER && OtherVehicleCount > 0)
                    {
                        this.TotalVehicleParked -= 1;
                        vehicleList.Remove(vehicle);
                        OtherVehicleCount -= 1;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        private bool IsParkingSlotEmpty()
        {
            if (TotalVehicleParked < TotalParkingCapacity)
                return true;
            else
                return false;
        }
    }
}