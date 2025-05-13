using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    class connection_string
    {
        private static connection_string instance;
        private string connectionString;
        private SqlConnection connection;

        // Private constructor to initialize the connection
        private connection_string()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=pos;Integrated Security=True;TrustServerCertificate=True";
            connection = new SqlConnection(connectionString); // Assigning the class-level connection variable
        }

        // Singleton pattern to get the instance of the connection_string class
        public static connection_string Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new connection_string();
                }
                return instance;
            }
        }

        // Method to get the SqlConnection
        public SqlConnection GetConnection()
        {
            return connection;
        }

        // Method to open the connection
        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        // Method to close the connection
        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
