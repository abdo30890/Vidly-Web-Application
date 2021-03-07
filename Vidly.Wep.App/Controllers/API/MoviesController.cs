using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Wep.App.DTO;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.Controllers.API
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context= new ApplicationDbContext();

        public MoviesController()
        {
         
            _context = new ApplicationDbContext();
        }

        //GET /api/Movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {

            var list = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(list);
        }

        //Get /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        //Post /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        //Put /api/Movies
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
               return BadRequest();

            var movieinDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieinDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieinDb);
            _context.SaveChanges();
            return Ok();

        }

        //Delete /api/Movies
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieinDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieinDb == null)
                return NotFound();

            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
