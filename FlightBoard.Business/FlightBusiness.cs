using FlightBoard.Data;
using FlightBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoard.Business
{
    public class FlightBusiness
    {
        private FlightData flightData = new FlightData();

        public List<FlightInfo> GetAllFlights()
        {
            return flightData.GetAllFlights();
        }

        public void AddFlight(FlightInfo flight)
        {
            flightData.InsertFlight(flight);
        }

        public void EditFlight(FlightInfo flight)
        {
            flightData.UpdateFlight(flight);
        }

        public void RemoveFlight(int flightId)
        {
            flightData.DeleteFlight(flightId);
        }
    }
}
