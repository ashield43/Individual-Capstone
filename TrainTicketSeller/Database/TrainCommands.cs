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
    class TrainCommands
    {
        // Gets all trains from the database
        public static List<Train> GetTrains()
        {
            List<Train> trains = new List<Train>();

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "SELECT * FROM Train";
            SqlCommand command = new SqlCommand(statement, connection);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Train train = new Train();
                    train.TrainID = (int)reader["TrainID"];
                    train.TrainName = reader["Name"].ToString();
                    train.NumberOfSeats = (int)reader["Seats"];

                    trains.Add(train);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();

            return trains;
        }

        // Tests if a train has already been generated on a given day
        public static bool TrainRouteExists(Train train)
        {
            bool exists = false;

            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "SELECT * FROM RouteStopAvailability WHERE TrainID = @TrainID AND LegID = @LegID AND Date = @DepartureDate";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@TrainID", train.TrainID);
            command.Parameters.AddWithValue("@LegID", train.ListOfLegs[0].LegID);
            command.Parameters.AddWithValue("@DepartureDate", train.DepartureDate);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    exists = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();

            return exists;
        }

        // Add a train to the database
        public static int AddTrain(Train train)
        {
            int trainID = -1;
            SqlConnection connection = ConnectionString.GetConnection();
            String statement = "INSERT Train (Name, Seats) values(@Name, @Seats); SELECT CAST(scope_identity() AS int)";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@Name", train.TrainName);
            command.Parameters.AddWithValue("@Seats", train.NumberOfSeats);

            try
            {
                connection.Open();
                trainID = (int)command.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
            finally
            {
                connection.Close();
            }

            return trainID;
        }
    }
}
