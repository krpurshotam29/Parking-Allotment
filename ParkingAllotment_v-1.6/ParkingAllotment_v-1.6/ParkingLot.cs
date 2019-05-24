using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{ 
    class ParkingLot
    {
        private List<ParkingSlot> ParkingSlotList;
        private List<Ticket> TicketList;
        private int ticketNumber;

        public ParkingLot(int twoWheelerSlot, int fourWheelerslot, int otherVehilceSlot)
        {
            ParkingSlotList = new List<ParkingSlot>();
            int slotId = (new Random()).Next(100);
            ticketNumber = (new Random()).Next(100,999);
            for (int i = 0; i < twoWheelerSlot; i++)
                ParkingSlotList.Add(new ParkingSlot(new Vehicle(VehicleType.TWO_WHEELER,""),"S-"+(slotId++)));
            for (int i = 0; i < fourWheelerslot; i++)
                ParkingSlotList.Add(new ParkingSlot(new Vehicle(VehicleType.FOUR_WHEELER, ""), "S-" + (slotId++)));
            for (int i = 0; i < otherVehilceSlot; i++)
                ParkingSlotList.Add(new ParkingSlot(new Vehicle(VehicleType.OTHER, ""), "S-" + (slotId++)));

            TicketList = new List<Ticket>();
        }

        public string Park(Vehicle vehicle)
        {
            foreach(ParkingSlot parkingSlot in ParkingSlotList)
            {
                if(parkingSlot.vehicle.vehicleType==vehicle.vehicleType && !parkingSlot.Booked)
                {
                    parkingSlot.vehicle = vehicle;
                    parkingSlot.Booked = true;
                    TicketList.Add(new Ticket(vehicle, "T"+(ticketNumber++),parkingSlot.SlotId));
                    return ("T"+(ticketNumber-1));
                }
            }
            throw (new Exception("Parking Slots are Full"));
        }

        public void UnPark(Vehicle vehicle)
        {
            bool unparked = false;
            foreach(ParkingSlot parkingSlot in ParkingSlotList)
            {
                if(parkingSlot.vehicle.VehicleNumber==vehicle.VehicleNumber && parkingSlot.vehicle.vehicleType == vehicle.vehicleType)
                {
                    parkingSlot.vehicle = new Vehicle(vehicle.vehicleType, "");
                    parkingSlot.Booked = false;
                    unparked = true;
                    break;
                }
            }
            if (!unparked)
                throw (new Exception("Vehicle not found"));
        }

        public Vehicle GetVehicle(string ticketNumber)
        {
            foreach (Ticket ticket in TicketList)
            {
                if (ticket.TicketNumber == ticketNumber)
                {
                    ticket.OutTime = DateTime.Now;
                    return ticket.vehicle;
                }
            }
            throw (new Exception("Ticket not Found"));
        }

        public List<ParkingSlot> GetParkingSlotList()
        {
            return ParkingSlotList;
        }

        public List<Ticket> GetTicketList()
        {
            return TicketList;
        }
        
    }
}
