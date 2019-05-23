using System;

namespace ParkingAllotmentSystem
{
	public class Ticket
	{
        public DateTime InTime { get; private set; }
        public DateTime ? OutTime {  get; set; }
        public string TicketNumber { get; private set; }

        public Ticket(string TicketNumber)
        {
            this.InTime = DateTime.Now;
            this.TicketNumber = TicketNumber;
            this.OutTime = null;
        }
	}
}
