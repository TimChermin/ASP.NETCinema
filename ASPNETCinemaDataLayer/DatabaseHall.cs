using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DataLayer
{
    public class DatabaseHall
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);
        private List<HallModel> halls;

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public List<HallModel> GetHalls()
        {
            //using ASPNETCinema.Models; added
            halls = new List<HallModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Hall", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    HallModel hall = new HallModel(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                    halls.Add(hall);
                }
            }

            connection.Close();
            return (halls);
        }

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

        public void EditHall(HallModel hall)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Hall SET Price = @Price, ScreenType = @ScreenType, Seats = @Seats, " +
                "SeatsTaken = @SeatsTaken WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", hall.Id);
            command.Parameters.AddWithValue("@Price", hall.Price);
            command.Parameters.AddWithValue("@ScreenType", hall.ScreenType);
            command.Parameters.AddWithValue("@Seats", hall.Seats);
            command.Parameters.AddWithValue("@SeatsTaken", hall.SeatsTaken);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteHall(int id)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Hall WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        
    }
}
