using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingAllotmentSystem
{
	public class ParkingSlot
    {
        public Vehicle vehicle { get; set;}
        public string SlotId { get; set; }

        public ParkingSlot(string slotId, Vehicle vehicle)
        {
            this.vehicle = vehicle;
            this.SlotId = slotId;
        }
    }
}
