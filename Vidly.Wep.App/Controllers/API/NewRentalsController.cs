using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Wep.App.DTO;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        //[HttpPost]
        //public IHttpActionResult CreareNewRentals(NewRentalDto newRental)
        //{
        //    if (newRental.MovieIds.Count == 0)
        //        return BadRequest("No Movie Ids have been given.");
        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
        //    if (customer == null)
        //        return BadRequest("Customer Id Isn't Valid'");
        //    var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
        //    if (movies.Count != newRental.MovieIds.Count)
        //        return BadRequest("One Or More Movies Ids Isn't Valid");
        //    foreach (var movie in movies )
        //    {
        //        if (movie.NumberAvailable == 0)
        //            return BadRequest("Movie Isn't Available");
        //        movie.NumberAvailable--;
        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = movie,
        //            DateRented = DateTime.Now
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();
        //    return Ok();

        //}
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
