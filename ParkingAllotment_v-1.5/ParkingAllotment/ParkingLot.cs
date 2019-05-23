using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAllotmentSystem
{
    public class ParkingLot
    {
        private List<ParkingSlot> ParkingSlotList;
        private List<Ticket> TicketList;

        public ParkingLot(int TwoWheelerCapacity, int FourWheelerCapacity, int OtherVehicleCapacity)
        {
            ParkingSlotList = new List<ParkingSlot>();
            int slotId = 100;
            for(int i=0;i<TwoWheelerCapacity;i++)
                ParkingSlotList.Add(new ParkingSlot("T"+(slotId++),new Vehicle(VehicleType.TWO_WHEELER,"")));
            for(int i=0;i<FourWheelerCapacity;i++)
                ParkingSlotList.Add(new ParkingSlot("F"+(slotId++),new Vehicle(VehicleType.FOUR_WHEELER,"")));
            for(int i=0;i<OtherVehicleCapacity;i++)
                ParkingSlotList.Add(new ParkingSlot("O"+(slotId++),new Vehicle(VehicleType.OTHER,"")));
            this.TicketList = new List<Ticket>();
        }

        public List<ParkingSlot> GetParkingSlotList()
        {
            return ParkingSlotList;
        }

        public List<Ticket> GetTicketList(){
            return TicketList;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            bool parked = false;
            foreach(ParkingSlot parkingSlot in ParkingSlotList){
                if(parkingSlot.vehicle.vehicleType==vehicle.vehicleType && !parkingSlot.Booked){
                    parkingSlot.Booked = true;
                    parkingSlot.vehicle = vehicle;
                    parked = true;
                    break;
                }
            }
            if(!parked)
                throw (new ListException("Parking Slot not Available"));
        }

        public void UnParkVehicle(Vehicle vehicle)
        {
            bool unParked = false;
            foreach(ParkingSlot parkingSlot in ParkingSlotList){
                if(parkingSlot.vehicle.VehicleNumber==vehicle.VehicleNumber && parkingSlot.vehicle.vehicleType==vehicle.vehicleType && parkingSlot.Booked){
                    parkingSlot.Booked = false;
                    parkingSlot.vehicle = vehicle;
                    unParked = true;
                    break;
                }
            }
            if(!parked)
                throw (new ListException("No Vehicle found with the given details"));
        }
    }
}