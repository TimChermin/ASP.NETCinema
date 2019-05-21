using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ASPNETCinema.DAL
{
    public class DatabaseConnection
    {
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal SqlConnection SqlConnection { get; }
        internal string connectionString { get; set; }
    }
}
