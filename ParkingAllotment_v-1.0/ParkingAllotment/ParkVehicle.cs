using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class ParkVehicle
    {
        private int SLOT_FULL_ERROR = 1;
        private int VEHICLE_NOT_FOUND_ERROR = 2;
        private int INVALID_CAPACITY_ERROR = 3;

        public void CreateAllotment(out ParkingSlot parkingSlot)
        {
            Console.Clear();
            Console.WriteLine("*********** Welcome to Parking Allotment ***********");
            Console.Write("Enter the number of slots for 2 wheelers    : ");
            string twoWheeler = Console.ReadLine();
            Console.Write("Enter the number of slots for 4 wheelers    : ");
            string fourWheeler = Console.ReadLine();
            Console.Write("Enter the number of slots for other vehicle : ");
            string otherVehilce = Console.ReadLine();
            if ((Convert.ToInt32(twoWheeler) < 0 || Convert.ToInt32(fourWheeler) < 0 || Convert.ToInt32(otherVehilce) < 0) ||
                (Convert.ToInt32(twoWheeler) > int.MaxValue || Convert.ToInt32(fourWheeler) > int.MaxValue || Convert.ToInt32(otherVehilce) > int.MaxValue) ||
                (Convert.ToInt32(twoWheeler) < int.MinValue || Convert.ToInt32(fourWheeler) < int.MinValue || Convert.ToInt32(otherVehilce) < int.MinValue))
            {
                Error(3);
                Console.ReadLine();
                CreateAllotment(out parkingSlot);
            }
            else
            {
                parkingSlot = new ParkingSlot(int.Parse(twoWheeler), int.Parse(fourWheeler), int.Parse(otherVehilce));
            }
        }

        public void DisplayMenu(ParkingSlot parkingSlot)
        {
            while (true)
            {
                Console.WriteLine("\n\n1. Park Vehicle");
                Console.WriteLine("2. Unpark Vehicle");
                Console.WriteLine("3. Display All Slots");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose any option");
                string choice = Console.ReadLine();
                if (choice == "4")
                    break;
                SelectOption(int.Parse(choice), parkingSlot);
            }
        }

        public void SelectOption(int choice, ParkingSlot parkingSlot)
        {
            switch (choice)
            {
                case 1:
                    VehicleType vehicle;
                    string vehicleNumber = ReadVehicleDetail(out vehicle);
                    while (vehicle == VehicleType.NONE)
                        vehicleNumber = ReadVehicleDetail(out vehicle);
                    if (!parkingSlot.ParkVehicle(vehicle, vehicleNumber))
                        Error(1);
                    break;
                case 2:
                    VehicleType vehicle2;
                    string vehicleNumber2 = ReadVehicleDetail(out vehicle2);
                    while (vehicle2 == VehicleType.NONE)
                        vehicleNumber2 = ReadVehicleDetail(out vehicle2);
                    if (!parkingSlot.UnParkVehicle(vehicle2, vehicleNumber2))
                        Error(2);
                    break;
                case 3:
                    DisplayAllSlots(parkingSlot);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public string ReadVehicleDetail(out VehicleType vehicleType)
        {
            Console.WriteLine("Enter the type of vehicle : ");
            Console.WriteLine("     1. Two Wheeler");
            Console.WriteLine("     2. Four Wheeler");
            Console.WriteLine("     3. Other");
            string readVehicleType = Console.ReadLine();
            if (int.Parse(readVehicleType) == 1)
                vehicleType = VehicleType.TWO_WHEELER;
            else if (int.Parse(readVehicleType) == 2)
                vehicleType = VehicleType.FOUR_WHEELER;
            else if (int.Parse(readVehicleType) == 3)
                vehicleType = VehicleType.OTHER;
            else
            {
                vehicleType = VehicleType.NONE;
                Console.WriteLine("Invalid Choice");
                return "";
            }
            Console.WriteLine("Enter the vehicle number : ");
            return (Console.ReadLine());
        }

        public void DisplayAllSlots(ParkingSlot parkingslot)
        {
            Console.WriteLine("\n\n******************  Parking Alloment Display  ******************");
            Console.WriteLine("Two Wheeler Parking Empty Slots   = " + parkingslot.GetEmptyTwoWheelerSlots());
            Console.WriteLine("Four Wheeler Parking Empty Slots  = " + parkingslot.GetEmptyFourWheelerSlots());
            Console.WriteLine("Other Vehicle Parking Empty Slots = " + parkingslot.GetEmptyOtherVehicleSlots());
            List<Vehicle> vehicleList = parkingslot.GetVehicleList();
            foreach(Vehicle vehicle in vehicleList)
            {
                Console.WriteLine("\nslot {0}\nVehicleType {1}\tVehicle no. {2} ",vehicleList.IndexOf(vehicle)+1,vehicle.GetNumberOfWheels(),vehicle.GetVehicleNumber());
            }
            Console.WriteLine("\n\n");
        }

        public void Error(int errorID)
        {
            if (errorID == SLOT_FULL_ERROR)
                Console.WriteLine("\nAll the solts are full\n");
            else if (errorID == VEHICLE_NOT_FOUND_ERROR)
                Console.WriteLine("\nNo vehicle found with the speficied details\n");
            else if (errorID == INVALID_CAPACITY_ERROR)
                Console.WriteLine("Invalid capacity of the slots");
        }
    }
}