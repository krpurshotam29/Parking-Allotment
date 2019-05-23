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

        public ParkingLot()
        {
            this.ParkingSlotList = new List<ParkingSlot>();
        }

        public int GetNumberOfVehiclesParked(VehicleType vehicleType)
        {
            return (from slot in ParkingSlotList where slot.vehicle.vehicleType == vehicleType select slot).Count();
        }

        public List<ParkingSlot> GetParkingSlotList()
        {
            return ParkingSlotList;
        }

        public void ParkVehicle(ParkingSlot parkingSlot)
        {
            ParkingSlotList.Add(parkingSlot);
        }

        public void UnParkVehicle(ParkingSlot parkingSlot)
        {
            ParkingSlotList.Remove(parkingSlot);
        }
    }
}