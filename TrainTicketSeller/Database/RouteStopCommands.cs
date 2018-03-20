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
    class RouteStopCommands
    {

        // Stores the availability of every leg of a train into the database
        // This is what keeps track of which legs on which trains have available seats on given days
        public static void AddRouteStopAvailability(Train train)
        {
            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "INSERT INTO RouteStopAvailability (TrainID, LegID, Date, AvailableSeats) VALUES (@TrainID, @LegID, @Date, @AvailableSeats)";
            SqlCommand command = new SqlCommand(statement, connection);

            try
            {
                connection.Open();
                foreach (Leg leg in train.ListOfLegs)
                {
                    command.Parameters.AddWithValue("@TrainID", train.TrainID);
                    command.Parameters.AddWithValue("@LegID", leg.LegID);
                    command.Parameters.AddWithValue("@Date", train.DepartureDate);
                    command.Parameters.AddWithValue("@AvailableSeats", leg.SeatsAvailable);

                    command.ExecuteNonQuery();
                    // Clear the parameters after every use to allow the legID and SeatsAvailable variables to change for each leg
                    command.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                connection.Close();
            }
        }

        // Updates the seat availability of one specific existing leg
        public static void UpdateRouteStopAvailability(Train train, int index)
        {
            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "UPDATE RouteStopAvailability SET AvailableSeats = @AvailableSeats"
                + " WHERE TrainID = @TrainID AND LegID = @LegID AND Date = @Date";
            SqlCommand command = new SqlCommand(statement, connection);

            try
            {
                connection.Open();

                command.Parameters.AddWithValue("@TrainID", train.TrainID);
                command.Parameters.AddWithValue("@LegID", train.ListOfLegs[index].LegID);
                command.Parameters.AddWithValue("@Date", train.DepartureDate);
                command.Parameters.AddWithValue("@AvailableSeats", train.ListOfLegs[index].SeatsAvailable);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                connection.Close();
            }
        }

        // Clears the table of all rows prior to the current date
        // Keeps the table clear
        // Consider moving the data to a seperate table in the future, rather than delete it
        public static void ClearRouteStopAvailabilty()
        {
            DateTime today = DateTime.Today;

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "DELETE from RouteStopAvailability WHERE Date < @Date";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@Date", today);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Connects a legID to its corresponding train and sets which stop the leg is
        // Important for keeping the train route in order so City B never comes before City A
        public static void AddRouteStop(Train train, Leg leg, int stopNumber)
        {
            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "INSERT INTO RouteStops (TrainID, LegID, StopNumber) VALUES (@TrainID, @LegID, @StopNumber)";
            SqlCommand command = new SqlCommand(statement, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@TrainID", train.TrainID);
                command.Parameters.AddWithValue("@LegID", leg.LegID);
                command.Parameters.AddWithValue("@StopNumber", stopNumber);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
            finally
            {
                connection.Close();
            }
        }
    }
}
