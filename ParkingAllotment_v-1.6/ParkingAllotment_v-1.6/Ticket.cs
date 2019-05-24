using System;
namespace ParkingAllotmentSystem
{
    public class Ticket
    {
        public string VehicleNumber;
        public DateTime InTime;
        public DateTime ? OutTime;
        public string TicketNumber;
        public string SlotId;

        public Ticket(string vehicleNumber,string ticketNumber,string slotId)
        {
            this.VehicleNumber = vehicleNumber;
            this.TicketNumber = ticketNumber;
            InTime = DateTime.Now;
            OutTime = null;
            this.SlotId = slotId;
        }
    }
}