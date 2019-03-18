using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using System.Data.SqlClient;
using DAL;
using Interfaces;

namespace ASPNETCinema.DAL
{
    public class DatabaseMovie : IMovieContext
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);
        private string orderBy = null;

        public List<MovieModel> Movies { get; set; }
        public string OrderBy { get => orderBy; set => orderBy = value; }


        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        

        IEnumerable<IMovie> IMovieContext.GetMovies()
        {
            //using ASPNETCinema.Models; added
            Movies = new List<MovieModel>();
            connection.Open();
            SqlCommand command;
            if (orderBy == "MoviesToday")
            {
                command = new SqlCommand("SELECT * FROM Movie GROUP BY Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString HAVING ReleaseDate = @Today", connection);
                command.Parameters.AddWithValue("@Today", DateTime.Today);
            }
            else if (orderBy != null)
            {
                command = new SqlCommand("SELECT * FROM Movie ORDER BY @orderBy", connection);
                command.Parameters.AddWithValue("@OrderBy", orderBy);
            }
            else
            {
                command = new SqlCommand("SELECT * FROM Movie", connection);
            }

            var movies = new List<IMovie>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new MovieModel
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"]?.ToString(),
                        Description = reader["Description"]?.ToString(),
                        ReleaseDate = (DateTime)reader["ReleaseDate"],
                        LastScreeningDate = (DateTime)reader["LastScreeningDate"],
                        MovieType = reader["MovieType"]?.ToString(),
                        MovieLenght = reader["MovieLenght"]?.ToString(),
                        ImageString = reader["ImageString"]?.ToString()
                    };

                    movies.Add(movie);
                }
            }

            connection.Close();
            return (movies);
        }

        public void Add(IMovie movie)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Movie OUTPUT Inserted.Id VALUES (@Name, @Description, @ReleaseDate, @LastScreeningDate, @MovieType, @MovieLenght, @ImageString)", connection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            MovieModel newMovie = new MovieModel(((int)command.ExecuteScalar()), movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate, movie.MovieType, movie.MovieLenght, movie.ImageString);

            connection.Close();
        }

        public IMovie GetById(int id)
        {
            Movies = new List<MovieModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Movie WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    IMovie movie = new MovieModel
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"]?.ToString(),
                        Description = reader["Description"]?.ToString(),
                        ReleaseDate = (DateTime)reader["ReleaseDate"],
                        LastScreeningDate = (DateTime)reader["LastScreeningDate"],
                        MovieType = reader["MovieType"]?.ToString(),
                        MovieLenght = reader["MovieLenght"]?.ToString(),
                        ImageString = reader["ImageString"]?.ToString()
                    };

                    return movie;
                }
            }
            return null;
        }

        public void EditMovie(MovieModel movie)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Movie SET Name = @Name, Description = @Description, ReleaseDate = @ReleaseDate, " +
                "LastScreeningDate = @LastScreeningDate, MovieType = @MovieType, MovieLenght = @MovieLenght, ImageString = @ImageString WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            command.Parameters.AddWithValue("@Id", movie.Id);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(IMovie movie)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Movie WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", movie.Id);
            command.ExecuteNonQuery();

            connection.Close();
        }
        
    }
}
