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

        public ParkingSlot Park(Vehicle vehicle)
        {
            ParkingSlot freeSlot = ParkingSlotList.Find(e => !e.IsBooked && e.vehicle.vehicleType==vehicle.vehicleType);
            if(freeSlot!=null){
                freeSlot.vehicle = vehicle;
                freeSlot.IsBooked = true;
                return(freeSlot);

            }else{
                throw (new Exception("Parking Slots are Full"));
            }
        }

        public string GenerateTicket(ParkingSlot parkingSlot){
            TicketList.Add(new Ticket(parkingSlot.vehicle,"T-"+(TicketList.Count()+1),parkingSlot.SlotId));
            return("T-"+(TicketList.Count()));
        }

        public void UnPark(Vehicle vehicle)
        {
            bool unparked = false;
            ParkingSlot occupiedSlot = ParkingSlotList.Find(e => e.vehicle.VehicleNumber==vehicle.VehicleNumber && e.vehicle.vehicleType==vehicle.vehicleType);
            if(occupiedSlot!=null){
                occupiedSlot.vehicle = new Vehicle(vehicle.vehicleType,"");
                occupiedSlot.IsBooked = false;
            }else{
                throw (new Exception("Vehicle not found"));
            }
        }

        public ParkingSlot GetParkingSlot(Ticket ticket)
        {
            ParkingSlot parkingSlot = ParkingSlotList.Find(e => e.SlotId == ticket.SlotId);            
            if(parkingSlot!=null)
                return(parkingSlot);
            else
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
