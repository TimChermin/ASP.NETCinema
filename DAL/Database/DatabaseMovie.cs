using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using DAL.Dtos;
using ASPNETCinema.Models;

namespace ASPNETCinema.DAL
{
    public class DatabaseMovie : IMovieContext
    {
        private readonly DatabaseConnection _connection;
        
        public DatabaseMovie(DatabaseConnection connection)
        {
            _connection = connection;
        }


        public List<MovieDto> GetMovies(string orderBy)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                var movies = new List<MovieDto>();
                SqlCommand command;
                if (orderBy == "MoviesToday")
                {
                    command = new SqlCommand("EXEC dbo.spMovie_GetAllMoviesToday @Today", conn);
                    command.Parameters.AddWithValue("@Today", DateTime.Today);
                }
                else if (orderBy == null)
                {
                    command = new SqlCommand("SELECT * FROM Movie", conn);
                }
                else
                {
                    command = new SqlCommand(@"SELECT * FROM Movie order by 
                case when @var = 'Name' then Name end desc,
                case when @var = 'ReleaseDate' then ReleaseDate end desc,
                case when @var = 'MovieType' then MovieType end desc", conn);
                    command.Parameters.AddWithValue("@var", orderBy);
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
                return (movies);
            }
        }

        public void AddMovie(MovieModel movie)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"INSERT INTO Movie OUTPUT Inserted.Id VALUES (@Name, @Description, @ReleaseDate, @LastScreeningDate, 
            @MovieType, @MovieLenght, @ImageString, @BannerImageString)", conn);
                command.Parameters.AddWithValue("@Name", movie.Name);
                command.Parameters.AddWithValue("@Description", movie.Description);
                command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                command.Parameters.AddWithValue("@LastScreeningDate", movie.LastScreeningDate);
                command.Parameters.AddWithValue("@MovieType", movie.MovieType);
                command.Parameters.AddWithValue("@MovieLenght", movie.MovieLenght);
                command.Parameters.AddWithValue("@ImageString", movie.ImageString);
                command.Parameters.AddWithValue("@BannerImageString", movie.BannerImageString);
                command.ExecuteNonQuery();
            }
        }

        public MovieDto GetMovieById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString, BannerImageString FROM Movie 
            WHERE Id = @Id", conn);
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
                        return movie;
                    }
                }
                return null;
            }
        }

        public void EditMovie(MovieModel movie)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(@"UPDATE Movie SET Name = @Name, Description = @Description, ReleaseDate = @ReleaseDate, 
            LastScreeningDate = @LastScreeningDate, MovieType = @MovieType, MovieLenght = @MovieLenght, ImageString = @ImageString, 
            BannerImageString = @BannerImageString WHERE Id = @Id", conn);
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
            }
        }

        public void DeleteMovie(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                //EXEC SelectAllCustomers City = "London";
                SqlCommand command = new SqlCommand("spMovie_DeleteMovie", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@movieId", id);
                command.ExecuteNonQuery();
            }
        }

        public List<ScreeningDto> GetScreeningsForMovie(int idMovie)
        {
            using (SqlConnection conn = new SqlConnection(_connection.connectionString))
            {
                conn.Open();
                SqlCommand command;
                var screenings = new List<ScreeningDto>();
                DateTime ScreeningDateCheck = new DateTime(1800, 2, 3);
                command = new SqlCommand(@"SELECT Id, IdMovie, IdHall, DateOfScreening, TimeOfScreening FROM Screening WHERE 
            IdMovie = @IdMovie ORDER BY TimeOfScreening", conn);
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
                return screenings;
            }
        }
    }
}
