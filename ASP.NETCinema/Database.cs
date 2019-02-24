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



        public List<MovieModel> GetMovies()
        {
            //using ASPNETCinema.Models; added
            List<MovieModel> movies = new List<MovieModel>();

            string query = "SELECT  Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght " +
            "FROM Movie ";

            //Open the connection and make the SQL command with query
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                //Keep going until all the data has been read
                while (reader.Read())
                {
                    //Read the data in Movies (from table to object)
                    MovieModel movie = new MovieModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6));

                    //Add the Movies to the list
                    movies.Add(movie);
                }
            }

            //Close the connection and return the Movies
            connection.Close();
            return (movies);
        }


        public void AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            //open the connection
            connection.Open();
            MovieModel movie = new MovieModel(name, description, releaseDate, lastScreeningDate, movieType, movieLenght);

            //create the query
            string query = "INSERT INTO Movie OUTPUT Inserted.Id VALUES ('" + movie.Name + "', '" + movie.Description + "', '" + movie.ReleaseDate + "', '" + movie.LastScreeningDate + "', '" + movie.MovieType + "', '" + movie.MovieLenght + "')";
            SqlCommand command = new SqlCommand(query, connection);
            //run the query and get the new iD
            movie.ID = (int)command.ExecuteScalar();

            //close the connection and go to the ListMovies view 
            connection.Close();
        }

    }
}
