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

        public int GetNumberOfTwoWheelerParked()
        {
            IEnumerable<ParkingSlot> numberOfTwoWheelerParked = from slot in ParkingSlotList where slot.vehicle.vehicleType == VehicleType.TWO_WHEELER select slot;
            return numberOfTwoWheelerParked.Count();
        }

        public int GetNumberOfFourWheelerParked()
        {
            IEnumerable<ParkingSlot> numberOfFourWheelerParked = from slot in ParkingSlotList where slot.vehicle.vehicleType == VehicleType.FOUR_WHEELER select slot;
            return numberOfFourWheelerParked.Count();
        }

        public int GetNumberOfOtherVehicleParked()
        {
            IEnumerable<ParkingSlot> numberOfOtherVehicleParked = from slot in ParkingSlotList where slot.vehicle.vehicleType == VehicleType.OTHER select slot;
            return numberOfOtherVehicleParked.Count();
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