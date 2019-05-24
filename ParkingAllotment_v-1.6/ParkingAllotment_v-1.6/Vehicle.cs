namespace ParkingAllotmentSystem
{
    public class Vehicle
    {
        public VehicleType vehicleType { get; private set; }
        public string VehicleNumber { get; set; }

        public Vehicle(VehicleType vehicleType, string vehicleNumber)
        {
            this.vehicleType = vehicleType;
            this.VehicleNumber = vehicleNumber;
        }
    }
}