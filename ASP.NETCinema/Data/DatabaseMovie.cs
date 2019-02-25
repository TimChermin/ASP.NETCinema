using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema
{
    public class DatabaseMovie
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);
        private string orderBy = null;

        public List<MovieModel> movies { get; set; }
        public string OrderBy { get => orderBy; set => orderBy = value; }

        public List<MovieModel> GetMovies()
        {
            //using ASPNETCinema.Models; added
            movies = new List<MovieModel>();
            connection.Open();
            SqlCommand command;
            if (orderBy != null)
            {
                command = new SqlCommand("SELECT * FROM Movie ORDER BY " + orderBy, connection);
                //command.Parameters.AddWithValue("@OrderBy", orderBy);
            }
            else
            {
                command = new SqlCommand("SELECT * FROM Movie", connection);
            }
            
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

        public List<MovieModel> GetMoviesToday()
        {
            //using ASPNETCinema.Models; added
            movies = new List<MovieModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Movie GROUP BY Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght HAVING ReleaseDate = @Today", connection);
            command.Parameters.AddWithValue("@Today", DateTime.Today);

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

    }
}
