using AutoMapper;
using ExamplesApp.DTOs;
using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace ExamplesApp.Controllers.Api
{
    public class MovieApiController : ApiController
    {

        private ApplicationDbContext _db;

        public MovieApiController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            var movieDto = _db.Movies
                 .Include(m => m.Genre)
                 .ToList()
                 .Select(Mapper.Map<Movie, MovieDto>);

            return movieDto;
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _db.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

                return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<MovieDto, Movie>(movieDto);

            _db.Movies.Add(customer);
            _db.SaveChanges();

            movieDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _db.Movies.Single(m => m.Id == id);

            if (movieInDb == null)
                return BadRequest();

            _db.Movies.Remove(movieInDb);
            _db.SaveChanges();
            return Ok();
        }
    }
}
