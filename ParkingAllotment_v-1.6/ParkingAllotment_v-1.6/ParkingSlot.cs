namespace ParkingAllotmentSystem
{
    class ParkingSlot
    {
        public Vehicle vehicle { get; set; }
        public string SlotId { get; set; }
        public bool Booked { get; set; }

        public ParkingSlot(Vehicle vehicle, string slotId)
        {
            this.vehicle = vehicle;
            this.SlotId = slotId;
            this.Booked = false;
        }
    }
}