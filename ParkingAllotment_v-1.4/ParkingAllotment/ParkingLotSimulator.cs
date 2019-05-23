using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class ParkingLotSimulator
    {
        private const int SLOT_FULL_ERROR = 1;
        private const int VEHICLE_NOT_FOUND_ERROR = 2;
        private const int INVALID_CAPACITY_ERROR = 3;
        private int TwoWheelerCapacity;
        private int FourWheelerCapacity;
        private int OtherVehicleCapacity;

        public void CreateAllotment(out ParkingLot parkingLot)
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
                Error(INVALID_CAPACITY_ERROR);
                Console.ReadLine();
                CreateAllotment(out parkingLot);
            }
            else
            {
                TwoWheelerCapacity = int.Parse(twoWheeler);
                FourWheelerCapacity = int.Parse(fourWheeler);
                OtherVehicleCapacity = int.Parse(otherVehilce);
                parkingLot = new ParkingLot();
            }
        }

        public void MainMenu(ParkingLot parkingLot)
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
                VehicleType vehicleType;
                ParkingSlot parkingSlot;
                switch (int.Parse(choice))
                {
                    case 1:
                        // add vehicle
                        parkingSlot = ReadVehicleDetail(out vehicleType);
                        while (vehicleType == VehicleType.NONE)
                            parkingSlot = ReadVehicleDetail(out vehicleType);
                        if(parkingLot.GetParkingSlotList().Where(e => e.vehicle.vehicleType==VehicleType.TWO_WHEELER).Count()<TwoWheelerCapacity && parkingLot.GetParkingSlotList().Where(e => e.vehicle.vehicleType==VehicleType.FOUR_WHEELER).Count()<FourWheelerCapacity && parkingLot.GetParkingSlotList().Where(e => e.vehicle.vehicleType==VehicleType.OTHER).Count()<OtherVehicleCapacity){
                            parkingLot.ParkVehicle(parkingSlot);
                        }else{
                            Error(SLOT_FULL_ERROR);
                        }
                        break;
                    case 2:
                        // remove vehicle
                        parkingSlot = ReadVehicleDetail(out vehicleType);
                        bool unParked = false;
                        while (vehicleType == VehicleType.NONE)
                            parkingSlot = ReadVehicleDetail(out vehicleType);
                        List<ParkingSlot> slotList = parkingLot.GetParkingSlotList();
                        foreach(ParkingSlot slot in slotList){
                            if(slot.vehicle.vehicleType==vehicleType && slot.vehicle.VehicleNumber==parkingSlot.vehicle.VehicleNumber){
                                parkingLot.UnParkVehicle(slot);
                                slot.ticket.OutTime = DateTime.Now;
                                unParked = true;
                            }
                        }
                        if(!unParked)
                            Error(VEHICLE_NOT_FOUND_ERROR);
                        break;
                    case 3:
                        DisplayAllSlots(parkingLot);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        public ParkingSlot ReadVehicleDetail(out VehicleType vehicleType)
        {
            Console.WriteLine("Enter the type of vehicle : ");
            Console.WriteLine("     1. Two Wheeler");
            Console.WriteLine("     2. Four Wheeler");
            Console.WriteLine("     3. Other");
            string readVehicleType = Console.ReadLine();
            if(int.Parse(readVehicleType)>0 && int.Parse(readVehicleType)<Enum.GetNames(typeof(VehicleType)).Length)
                vehicleType = (VehicleType) int.Parse(readVehicleType);
            else{
                vehicleType = VehicleType.NONE;
                Console.WriteLine("Invalid Choice");
                return (new ParkingSlot("",new Vehicle(vehicleType,""),new Ticket("")));
            }
            Console.WriteLine("Enter the vehicle number : ");
            string vehicleNumber = Console.ReadLine();
            Console.WriteLine("Enter the Parking Slot number : ");
            string slotNumber = Console.ReadLine();
            return(new ParkingSlot(slotNumber,new Vehicle(vehicleType,vehicleNumber), new Ticket(slotNumber)));
        }

        public void DisplayAllSlots(ParkingLot parkingLot)
        {
            Console.WriteLine("\n\n******************  Parking Alloment Display  ******************");
            List<ParkingSlot> slotList = parkingLot.GetParkingSlotList();
            Console.WriteLine("Two Wheeler Parking Empty Slots   = " + (TwoWheelerCapacity - slotList.Where(e => e.vehicle.vehicleType==VehicleType.TWO_WHEELER).Count()));
            Console.WriteLine("Four Wheeler Parking Empty Slots  = " + (FourWheelerCapacity - slotList.Where(e => e.vehicle.vehicleType==VehicleType.FOUR_WHEELER).Count()));
            Console.WriteLine("Other Vehicle Parking Empty Slots = " + (OtherVehicleCapacity -  slotList.Where(e => e.vehicle.vehicleType==VehicleType.OTHER).Count()));
            foreach(ParkingSlot slot in slotList)
            {
                Console.WriteLine("\n***** Slot Number : {0} *****",slot.SlotId);
                Console.WriteLine("VehicleType {0}\t\tVehicle no. {1} ",slot.vehicle.vehicleType,slot.vehicle.VehicleNumber);
                Console.WriteLine("Ticket No: {0}\t\tIn-Time: {1}\t\tOut-Time: {2}",slot.ticket.TicketNumber,slot.ticket.InTime,slot.ticket.OutTime);
            }
            Console.WriteLine("\n\n");
        }

        public void Error(int errorID)
        {
            switch (errorID){
                case SLOT_FULL_ERROR:
                    Console.WriteLine("\nAll the solts are full\n");
                    break;
                case VEHICLE_NOT_FOUND_ERROR:
                    Console.WriteLine("\nNo vehicle found with the speficied details\n");
                    break;
                case INVALID_CAPACITY_ERROR:
                    Console.WriteLine("Invalid capacity of the slots");
                    break;
            }      
        }
    }
}