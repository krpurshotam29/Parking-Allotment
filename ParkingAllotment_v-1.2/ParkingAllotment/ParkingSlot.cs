using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingAllotmentSystem
{
	public class ParkingSlot
    {
        private Vehicle vehicle;
        private string SlotId;

        public ParkingSlot(string slotId, Vehicle vehicle)
        {
            this.vehicle = vehicle;
            this.SlotId = slotId;
        }

        public Vehicle GetVehicle() {
            return vehicle;
        }

        public string GetSlotId() {
            return SlotId;
        }
    }
}
