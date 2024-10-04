using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoard.Models
{
    public class FlightInfo
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public TimeSpan ScheduledDep { get; set; }
        public TimeSpan ScheduledArr { get; set; }
        public TimeSpan BoardingTime { get; set; }
        public string GateNo { get; set; }
        public string Status { get; set; }
    }
}
