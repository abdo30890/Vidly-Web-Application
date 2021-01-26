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
            var movies = _context.Movies.Include(m => m.Genre).ToList();


           return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            { return HttpNotFound(); }

            return View(movie);
        }


    }

}