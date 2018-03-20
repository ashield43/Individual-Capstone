using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTicketSeller.Database
{
    class UserCommands
    {
        // Login specifically for admins
        public static bool AdminLogin(String username, String password)
        {
            SqlConnection connection = ConnectionString.GetConnection();
            string statement = "SELECT * FROM Admin WHERE Username = @Username AND Password = @Password";
            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            bool found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                found = reader.Read();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                connection.Close();
            }

            return found;
        }
    }
}
