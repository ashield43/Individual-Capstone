using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSeller.Database
{
    class ConnectionString
    {
        public static SqlConnection GetConnection()
        {
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\School Stuff\Object Oriented Design\TrainTicketSeller\TrainTicketSeller\Database.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
