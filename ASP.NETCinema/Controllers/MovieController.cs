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
        Database database = new Database();
       


        //GET
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            List<MovieModel> movies = database.GetMovies();
            return View(movies);
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            database.AddMovie(name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            return RedirectToAction("ListMovies");
        }

        public ActionResult EditMovie(int id)
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult EditMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
           
            return View();
        }


        // GET: Movies/Delete/5
        public ActionResult DeleteMovie(int? id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID && id != null)
                {
                    return View(movie);
                }
            }
            return NotFound();
        }

        /*// POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */


        public ActionResult Home()
        {
            return View();
        }

    }
}