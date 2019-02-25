using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema
{
    public class Database
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public List<MovieModel> movies { get; set; }



        public List<MovieModel> GetMovies()
        {
            //using ASPNETCinema.Models; added
            movies = new List<MovieModel>();

            string query = "SELECT * FROM Movie ";
            
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MovieModel movie = new MovieModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6));
                    
                    movies.Add(movie);
                }
            }
            
            connection.Close();
            return (movies);
        }


        public void AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            connection.Open();
           
            SqlCommand command = new SqlCommand("INSERT INTO Movie OUTPUT Inserted.ID VALUES (@Name, @Description, @ReleaseDate, @LastScreeningDate, @MovieType, @MovieLenght)", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", lastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movieType);
            command.Parameters.AddWithValue("@MovieLenght", movieLenght);
            MovieModel movie = new MovieModel(((int)command.ExecuteScalar()), name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            
            connection.Close();
        }

        public void DeleteMovie(int id)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Movie WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Movie SET Name = @Name, Description = @Description, ReleaseDate = @ReleaseDate, " +
                "LastScreeningDate = @LastScreeningDate, MovieType = @MovieType, MovieLenght = @MovieLenght WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", lastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movieType);
            command.Parameters.AddWithValue("@MovieLenght", movieLenght);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();


            connection.Close();
        }

    }
}
