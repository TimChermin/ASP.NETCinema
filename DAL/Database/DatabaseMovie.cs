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
        private string orderBy;
        private readonly DatabaseConnection _connection;
        public List<MovieModel> Movies { get; set; }

        public DatabaseMovie(DatabaseConnection connection)
        {
            _connection = connection;
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        IEnumerable<IMovie> IMovieContext.GetMovies(string orderBy)
        {
            //using ASPNETCinema.Models; added
            Movies = new List<MovieModel>();
            _connection.SqlConnection.Open();
            SqlCommand command;
            if (orderBy == "MoviesToday")
            {
                command = new SqlCommand("SELECT * FROM Movie GROUP BY Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString HAVING ReleaseDate = @Today", _connection.SqlConnection);
                command.Parameters.AddWithValue("@Today", DateTime.Today);
            }
            else if (orderBy == "Name" || orderBy == "ReleaseDate" || orderBy == "MovieType")
            {
                command = new SqlCommand("SELECT * FROM Movie ORDER BY " + orderBy, _connection.SqlConnection);
            }
            else
            {
                command = new SqlCommand("SELECT * FROM Movie", _connection.SqlConnection);
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
            
            return (movies);
        }

        public void AddMovie(IMovie movie)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Movie OUTPUT Inserted.Id VALUES (@Name, @Description, @ReleaseDate, @LastScreeningDate, @MovieType, @MovieLenght, @ImageString)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            command.ExecuteNonQuery();
        }

        public IMovie GetMovieById(int id)
        {
            Movies = new List<MovieModel>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Movie WHERE Id = @Id", _connection.SqlConnection);
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

        public void EditMovie(IMovie movie)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Movie SET Name = @Name, Description = @Description, ReleaseDate = @ReleaseDate, " +
                "LastScreeningDate = @LastScreeningDate, MovieType = @MovieType, MovieLenght = @MovieLenght, ImageString = @ImageString WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            command.Parameters.AddWithValue("@Id", movie.Id);

            command.ExecuteNonQuery();
        }

        public void DeleteMovie(int id)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Movie WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
