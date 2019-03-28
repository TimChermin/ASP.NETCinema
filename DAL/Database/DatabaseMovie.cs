using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using Interfaces;
using DAL.Dtos;

namespace ASPNETCinema.DAL
{
    public class DatabaseMovie : IMovieContext
    {
        private readonly DatabaseConnection _connection;
        
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


        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            _connection.SqlConnection.Open();

            var movies = new List<IMovie>();
            SqlCommand command;
            if (orderBy == "MoviesToday")
            {
                command = new SqlCommand("SELECT Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString, BannerImageString FROM Movie " +
                    "GROUP BY Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString, BannerImageString HAVING ReleaseDate = @Today", _connection.SqlConnection);
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

            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new MovieDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"]?.ToString(),
                        Description = reader["Description"]?.ToString(),
                        ReleaseDate = (DateTime)reader["ReleaseDate"],
                        LastScreeningDate = (DateTime)reader["LastScreeningDate"],
                        MovieType = reader["MovieType"]?.ToString(),
                        MovieLenght = reader["MovieLenght"]?.ToString(),
                        ImageString = reader["ImageString"]?.ToString(),
                        BannerImageString = reader["BannerImageString"]?.ToString()
                    };

                    movies.Add(movie);
                }
            }
            _connection.SqlConnection.Close();
            return (movies);
        }

        public void AddMovie(IMovie movie)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Movie OUTPUT Inserted.Id VALUES (@Name, @Description, @ReleaseDate, @LastScreeningDate, " +
                "@MovieType, @MovieLenght, @ImageString, @BannerImageString)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            command.Parameters.AddWithValue("@BannerImageString", movie.BannerImageString);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public IMovie GetMovieById(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString, BannerImageString FROM Movie " +
                "WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new MovieDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"]?.ToString(),
                        Description = reader["Description"]?.ToString(),
                        ReleaseDate = (DateTime)reader["ReleaseDate"],
                        LastScreeningDate = (DateTime)reader["LastScreeningDate"],
                        MovieType = reader["MovieType"]?.ToString(),
                        MovieLenght = reader["MovieLenght"]?.ToString(),
                        ImageString = reader["ImageString"]?.ToString(),
                        BannerImageString = reader["BannerImageString"]?.ToString()
                    };
                    _connection.SqlConnection.Close();
                    return movie;
                }
            }
            _connection.SqlConnection.Close();
            return null;
        }

        public void EditMovie(IMovie movie)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("UPDATE Movie SET Name = @Name, Description = @Description, ReleaseDate = @ReleaseDate, " +
                "LastScreeningDate = @LastScreeningDate, MovieType = @MovieType, MovieLenght = @MovieLenght, ImageString = @ImageString, BannerImageString = @BannerImageString WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Name", movie.Name);
            command.Parameters.AddWithValue("@Description", movie.Description);
            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
            command.Parameters.AddWithValue("@MovieType", movie.MovieType);
            command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
            command.Parameters.AddWithValue("@ImageString", movie.ImageString);
            command.Parameters.AddWithValue("@Id", movie.Id);
            command.Parameters.AddWithValue("@BannerImageString", movie.BannerImageString);

            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void DeleteMovie(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Movie WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public IEnumerable<IScreening> GetScreeningsForMovie(int idMovie)
        {
            _connection.SqlConnection.Open();
            SqlCommand command;
            var screenings = new List<IScreening>();
            DateTime ScreeningDateCheck = new DateTime(1800, 2, 3);
            command = new SqlCommand("SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening WHERE IdMovie = @IdMovie ORDER BY TimeOfScreening", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdMovie", idMovie);
            

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var screening = new ScreeningDto
                    {
                        Id = (int)reader["Id"],
                        MovieId = (int)reader["IdMovie"],
                        HallId = (int)reader["IdHall"],
                        DateOfScreening = (DateTime)reader["DateOfScreening"],
                        TimeOfScreening = (TimeSpan)reader["TimeOfScreening"]
                    };

                    screenings.Add(screening);
                }
            }
            _connection.SqlConnection.Close();
            return screenings;
        }
    }
}
