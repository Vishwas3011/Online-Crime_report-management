using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking
{
    public class Booking
    {
        public int airplaneId
        {
            get; set;
        }

        public string bookingFrom
        {
            get; set;
        }

        public string bookingTo
        {
            get; set;
        }
        public int totalSeats
        {
            get; set;
        }
        public int ticketPrice
        {
            get; set;
        }
        public string seatStatus
        {
            get; set;
        }
    }
}
