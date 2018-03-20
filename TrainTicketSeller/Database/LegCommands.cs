using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSeller.Business;

namespace TrainTicketSeller.Database
{
    class LegCommands
    {
        // Gets all legs a train travels
        public static List<Leg> GetLegs(int trainID)
        {
            List<Leg> legs = new List<Leg>();

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "SELECT * FROM Leg as l JOIN RouteStops as rs on rs.LegID = l.LegID WHERE rs.TrainID = @TrainID ORDER BY l.LegID";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@TrainID", trainID);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Leg leg = new Leg();
                    leg.LegID = (int)reader["LegID"];
                    leg.StartingCity = reader["StartingCity"].ToString();
                    leg.EndingCity = reader["EndingCity"].ToString();

                    legs.Add(leg);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();

            return legs;
        }

        // Gets the number of seats available for a specific leg on a route on a given day
        public static int GetLegAvailability(int trainID, int legID, DateTime departureDate)
        {
            int availableSeats = -1;

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "SELECT AvailableSeats FROM RouteStopAvailability WHERE TrainID = @TrainID AND LegID = @LegID AND Date = @DepartureDate";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@TrainID", trainID);
            command.Parameters.AddWithValue("@LegID", legID);
            command.Parameters.AddWithValue("@DepartureDate", departureDate.Date);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                availableSeats = (int)reader["AvailableSeats"];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return availableSeats;
        }

        // Adds a new leg to the database and returns the legID
        public static int AddLeg(Leg newLeg)
        {
            int legID = -1;

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "INSERT Leg (StartingCity, EndingCity) values(@StartingCity, @EndingCity); SELECT CAST(scope_identity() AS int)";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@StartingCity", newLeg.StartingCity);
            command.Parameters.AddWithValue("@EndingCity", newLeg.EndingCity);

            try
            {
                connection.Open();
                legID = (int)command.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return legID;
        }
    }
}
