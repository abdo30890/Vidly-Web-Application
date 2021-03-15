using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Wep.App.Models;
using Vidly.Wep.App.ViewModels;

namespace Vidly.Wep.App.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        ApplicationDbContext _context = new ApplicationDbContext();

        public ViewResult Index()
        {
            if(User.IsInRole("CanManageMovies"))
            return View("List");
            return View("ReadOnelyList");
        }

        [Authorize(Roles = "CanManageMovies")]
        public ViewResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie); 

            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                {
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            { return HttpNotFound(); }

            return View(movie);
        }

        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
            var editmovie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (editmovie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewMovieViewModel
            {
                Movie = editmovie,
                Genres = _context.Genres.ToList()

            };

            return View("Create", viewModel);
        }


    }

}