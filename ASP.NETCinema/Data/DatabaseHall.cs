using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Data
{
    public class DatabaseHall
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public void AddHall(HallModel hall)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Hall OUTPUT Inserted.ID VALUES (@Price, @ScreenType, @Seats, @SeatsTaken)", connection);
            command.Parameters.AddWithValue("@Price", hall.Price);
            command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
            command.Parameters.AddWithValue("@Seats", hall.Seats);
            command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);
            HallModel newHall = new HallModel(((int)command.ExecuteScalar()), hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);

            connection.Close();
        }


    }
}
