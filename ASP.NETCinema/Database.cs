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

            string query = "SELECT  Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght " +
            "FROM Movie ";
            
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
           
            string query = "INSERT INTO Movie OUTPUT Inserted.Id VALUES ('" + name + "', '" + description + "', '" + releaseDate + "', '" + lastScreeningDate + "', '" + movieType + "', '" + movieLenght + "')";
            SqlCommand command = new SqlCommand(query, connection);
            MovieModel movie = new MovieModel(((int)command.ExecuteScalar()), name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            
            connection.Close();
        }

        public void DeleteMovie(int id)
        {
            connection.Open();
            string query = "DELETE FROM Movie WHERE ID = " + id;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

    }
}
