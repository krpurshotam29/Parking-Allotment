using System;
namespace ParkingAllotmentSystem
{
    public class Ticket
    {
        public Vehicle vehicle;
        public DateTime InTime;
        public DateTime OutTime { get; set; }
        public string TicketNumber;
        public string SlotId;

        public Ticket(Vehicle vehicle,string ticketNumber,string slotId)
        {
            this.vehicle = vehicle;
            this.TicketNumber = ticketNumber;
            InTime = DateTime.Now;
            this.SlotId = slotId;
        }
    }
}