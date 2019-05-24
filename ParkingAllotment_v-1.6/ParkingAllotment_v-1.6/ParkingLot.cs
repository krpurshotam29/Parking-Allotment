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

        public ParkingLot(int twoWheelerSlot, int fourWheelerslot, int otherVehilceSlot)
        {
            ParkingSlotList = new List<ParkingSlot>();
            int slotId = (new Random()).Next(100);
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
                    TicketList.Add(new Ticket(vehicle.VehicleNumber, "T"+(TicketList.Count()+1),parkingSlot.SlotId));
                    return ("T"+(TicketList.Count()));
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

        public ParkingSlot GetParkingSlot(Ticket ticket)
        {
            foreach (ParkingSlot slot in ParkingSlotList)
            {
                if(ticket.SlotId==slot.SlotId)
                    return slot;
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
