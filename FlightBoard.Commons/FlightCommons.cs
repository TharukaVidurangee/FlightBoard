using FlightBoard.Business;
using FlightBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoard.Commons
{
    public class FlightCommons
    {
        private FlightBusiness flightBusiness = new FlightBusiness();

        public List<FlightInfo> GetAllFlights()
        {
            return flightBusiness.GetAllFlights();
        }

        public void AddFlight(FlightInfo flight)
        {
            flightBusiness.AddFlight(flight);
        }

        public void EditFlight(FlightInfo flight)
        {
            flightBusiness.EditFlight(flight);
        }

        public void RemoveFlight(int flightId)
        {
            flightBusiness.RemoveFlight(flightId);
        }
    }
}
