using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlightBoard.Models;

namespace FlightBoard.Data
{
    public class FlightData
    {
        private readonly string connectionString = "Data Source=DESKTOP-2JBM3A7;Initial Catalog=FlightBoard;Integrated Security=True";

        public List<FlightInfo> GetAllFlights()
        {
            var flights = new List<FlightInfo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM FlightInformation";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new FlightInfo
                    {
                        FlightId = (int)reader["FlightId"],
                        FlightDate = (DateTime)reader["FlightDate"],
                        FlightNumber = reader["FlightNumber"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        ScheduledDep = (TimeSpan)reader["ScheduledDep"],
                        ScheduledArr = (TimeSpan)reader["ScheduledArr"],
                        BoardingTime = (TimeSpan)reader["BoardingTime"],
                        GateNo = reader["GateNo"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return flights;
        }

        public void InsertFlight(FlightInfo flight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO FlightInformation (FlightDate, FlightNumber, Destination, ScheduledDep, ScheduledArr, BoardingTime, GateNo, Status) VALUES (@FlightDate, @FlightNumber, @Destination, @ScheduledDep, @ScheduledArr, @BoardingTime, @GateNo, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FlightDate", flight.FlightDate);
                cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                cmd.Parameters.AddWithValue("@ScheduledDep", flight.ScheduledDep);
                cmd.Parameters.AddWithValue("@ScheduledArr", flight.ScheduledArr);
                cmd.Parameters.AddWithValue("@BoardingTime", flight.BoardingTime);
                cmd.Parameters.AddWithValue("@GateNo", flight.GateNo);
                cmd.Parameters.AddWithValue("@Status", flight.Status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateFlight(FlightInfo flight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE FlightInformation SET FlightDate = @FlightDate, FlightNumber = @FlightNumber, Destination = @Destination, ScheduledDep = @ScheduledDep, ScheduledArr = @ScheduledArr, BoardingTime = @BoardingTime, GateNo = @GateNo, Status = @Status WHERE FlightId = @FlightId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FlightId", flight.FlightId);
                cmd.Parameters.AddWithValue("@FlightDate", flight.FlightDate);
                cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                cmd.Parameters.AddWithValue("@ScheduledDep", flight.ScheduledDep);
                cmd.Parameters.AddWithValue("@ScheduledArr", flight.ScheduledArr);
                cmd.Parameters.AddWithValue("@BoardingTime", flight.BoardingTime);
                cmd.Parameters.AddWithValue("@GateNo", flight.GateNo);
                cmd.Parameters.AddWithValue("@Status", flight.Status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFlight(int flightId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM FlightInformation WHERE FlightId = @FlightId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FlightId", flightId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
