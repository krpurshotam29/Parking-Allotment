using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    class ParkingAllotmentSimulator
    {
        public void MakeAllotment(out ParkingLot parkingLot)
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
                    string choice = Console.ReadLine();
                    if (int.Parse(choice) == 7)
                        break;
                    switch (int.Parse(choice))
                    {
                        case 1:
                            vehicle = ReadVehicleDetails();
                            try
                            {
                                Console.WriteLine("Your Ticket Number is : {0}",parkingLot.Park(vehicle));
                            }catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the Ticket Number");
                            string TicketNumber = Console.ReadLine();
                            try
                            {
                                vehicle = parkingLot.GetVehicle(TicketNumber);
                                parkingLot.UnPark(vehicle);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;
                        case 3:
                            DisplayAllSlots(parkingLot);
                            break;
                        case 4:
                            DisplaySlots(parkingLot,false);
                            break;
                        case 5:
                            DisplaySlots(parkingLot,true);
                            break;
                        case 6:
                            DisplayTicket(parkingLot);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                            
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
        }

        private void DisplayTicket(ParkingLot parkingLot)
        {
            List<Ticket> ticketList = parkingLot.GetTicketList();
            foreach(Ticket ticket in ticketList)
            {
                Console.WriteLine("Ticket No : {0}\tSlot No : {1}\tVehicle No : {2}\tIn-Time : {3}\tOut-Time : {4}", ticket.TicketNumber,ticket.SlotId,ticket.vehicle.VehicleNumber,ticket.InTime,ticket.OutTime);
            }
        }

        private void DisplaySlots(ParkingLot parkingLot, bool v)
        {
            IEnumerable<ParkingSlot> slotList = parkingLot.GetParkingSlotList().Where(e => e.Booked == v);
            foreach (ParkingSlot slot in slotList)
            {
                Console.WriteLine("Slot No : {0}\tVehilce type : {1}\tVehicle No : {2}\tBooked : {3}", slot.SlotId, slot.vehicle.vehicleType, slot.vehicle.VehicleNumber, slot.Booked);
            }
        }

        private void DisplayAllSlots(ParkingLot parkingLot)
        {
            List<ParkingSlot> parkingSlotList = parkingLot.GetParkingSlotList();
            foreach(ParkingSlot slot in parkingSlotList)
            {
                Console.WriteLine("Slot No : {0}\tVehilce type : {1}\tVehicle No : {2}\tBooked : {3}",slot.SlotId,slot.vehicle.vehicleType,slot.vehicle.VehicleNumber,slot.Booked);
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
                Console.WriteLine("Invalid integer");
            }
            return false;
        }
    }
}
