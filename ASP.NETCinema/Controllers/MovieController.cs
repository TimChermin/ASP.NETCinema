using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {

        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);


        //GET
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            //using ASPNETCinema.Models; added
            List<MovieModel> movies = new List<MovieModel>();

            string query = "SELECT  Id, Name, Description, MovieType, MovieLenght " +
            "FROM Movies ";

            //Open the connection and make the SQL command with query
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                //Keep going until all the data has been read
                while (reader.Read())
                {
                    //Read the data in Movies (from table to object)
                    MovieModel movie = new MovieModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));

                    //Add the Movies to the list
                    movies.Add(movie);
                }
            }

            //Close the connection and return the Movies
            connection.Close();
            return View(movies);
        }
    }
}