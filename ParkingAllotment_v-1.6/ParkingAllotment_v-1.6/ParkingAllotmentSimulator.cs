using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    class ParkingAllotmentSimulator
    {
        public void CreateSlots(out ParkingLot parkingLot)
        {
            string twoWheelerSlot, fourWheelerSlot, otherVehicleSlot;
            do
            {
                Console.Write("Enter the Slots for 2 Wheeler : ");
                twoWheelerSlot = Console.ReadLine();
            } while (!IsValidSlot(twoWheelerSlot));
            do
            {
                Console.Write("Enter the Slots for 4 Wheeler : ");
                fourWheelerSlot = Console.ReadLine();
            } while (!IsValidSlot(fourWheelerSlot));
            do
            {
                Console.Write("Enter the Slots for Other vehicle : ");
                otherVehicleSlot = Console.ReadLine();
            } while (!IsValidSlot(otherVehicleSlot));

            parkingLot = new ParkingLot(int.Parse(twoWheelerSlot),int.Parse(fourWheelerSlot),int.Parse(otherVehicleSlot));
        }


        public void MainMenu(ParkingLot parkingLot)
        {
            Console.Clear();
            Console.WriteLine("*******************  Welcome to Parking Allotment System  *******************");
            while (true)
            {
                Console.WriteLine("1. Park Vehicle");
                Console.WriteLine("2. UnPark Vehicle");
                Console.WriteLine("3. View All Slots");
                Console.WriteLine("4. View Available Slots");
                Console.WriteLine("5. View Booked Slots");
                Console.WriteLine("6. View All Tickets");
                Console.WriteLine("7. Exit");

                Vehicle vehicle;
                
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 7)
                        break;
                    switch (choice)
                    {
                        case 1:
                            //Park Vehicle
                            vehicle = ReadVehicleDetails();
                            ParkingSlot parkingSlot = parkingLot.Park(vehicle);
                            Console.WriteLine("Do you want ticket ? y/n");
                            if(Console.ReadLine()=="y"){
                                Ticket ticket = parkingLot.GenerateTicket(parkingSlot);
                                Console.WriteLine("Your Ticket Number is : {0}",ticket.TicketNumber);
                            }
                            break;
                        case 2:
                            //Unpark Vehicle
                            Console.WriteLine("Enter the Ticket Number");
                            string TicketNumber = Console.ReadLine();
                            Ticket ticket = parkingLot.GetTicketList().Where(e => e.TicketNumber==TicketNumber).First();
                            ParkingSlot slot = parkingLot.GetParkingSlot(ticket);
                            parkingLot.UnPark(slot.vehicle);
                            ticket.OutTime = DateTime.Now;
                            break;
                        case 3:
                            //Display All Slots
                            DisplayAllSlots(parkingLot);
                            break;
                        case 4:
                            //Display All Available Slots
                            DisplaySlots(parkingLot,false);
                            break;
                        case 5:
                            //Display All Booked Slots
                            DisplaySlots(parkingLot,true);
                            break;
                        case 6:
                            //Display Tickets
                            DisplayTicket(parkingLot);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                            
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        private void DisplayTicket(ParkingLot parkingLot)
        {
            List<Ticket> ticketList = parkingLot.GetTicketList();
            foreach(Ticket ticket in ticketList)
            {
                Console.WriteLine("Ticket No : {0}\tSlot No : {1}\tVehicle No : {2}\tIn-Time : {3}\tOut-Time : {4}", ticket.TicketNumber,ticket.SlotId,ticket.VehicleNumber,ticket.InTime,ticket.OutTime);
            }
        }


        private void DisplaySlots(ParkingLot parkingLot, bool v)
        {
            IEnumerable<ParkingSlot> slotList = parkingLot.GetParkingSlotList().Where(e => e.IsBooked == v);
            foreach (ParkingSlot slot in slotList)
            {
                Console.WriteLine("Slot No : {0}\tVehilce type : {1}\tVehicle No : {2}\tBooked : {3}", slot.SlotId, slot.vehicle.vehicleType, slot.vehicle.VehicleNumber, slot.IsBooked);
            }
        }


        private void DisplayAllSlots(ParkingLot parkingLot)
        {
            List<ParkingSlot> parkingSlotList = parkingLot.GetParkingSlotList();
            foreach(ParkingSlot slot in parkingSlotList)
            {
                Console.WriteLine("Slot No : {0}\tVehilce type : {1}\tVehicle No : {2}\tBooked : {3}",slot.SlotId,slot.vehicle.vehicleType,slot.vehicle.VehicleNumber,slot.IsBooked);
            }
        }


        private Vehicle ReadVehicleDetails()
        {
            try
            {
                Console.WriteLine("Enter the type of Vehicle :");
                Console.WriteLine("\t1. Two Wheeler");
                Console.WriteLine("\t2. Four Wheeler");
                Console.WriteLine("\t3. Other Vehicle Type");
                Console.Write("Enter your choice : ");
                string vehicleType = Console.ReadLine();
                if(vehicleType=="1" || vehicleType=="2" || vehicleType == "3")
                {
                    Console.WriteLine("Enter the vehilce number");
                    string VehicleNumber = Console.ReadLine();
                    return (new Vehicle((VehicleType)int.Parse(vehicleType), VehicleNumber));
                }
                else
                {
                    Console.WriteLine("\nInvalid Vehicle Type\n\n");
                    return ReadVehicleDetails();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("\nInvalid Choice\n\n");
                return ReadVehicleDetails();
            }
            
        }


        private bool IsValidSlot(string s)
        {
            try
            {
                int n = int.Parse(s);
                if (n >= 0 && n < int.MaxValue)
                    return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid number");
            }
            return false;
        }
    }
}
