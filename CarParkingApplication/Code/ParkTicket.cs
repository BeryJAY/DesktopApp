using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingApplication.Code
{
    class ParkTicket
    {
        public int TicketID { get; set; }
        public string DriverName { get; set; }
        public string License { get; set; }
        public string ParkName { get; set; }
        public DateTime Date { get; set; }
    }
}
