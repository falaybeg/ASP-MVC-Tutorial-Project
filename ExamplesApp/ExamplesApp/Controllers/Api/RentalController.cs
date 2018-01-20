using AutoMapper;
using ExamplesApp.DTOs;
using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ExamplesApp.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _db;
        public RentalController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var rentalDto = _db.Rental
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDto);
        }

        [HttpGet]
        public RentalDto GetById(int id)
        {
            var rentalDto = _db.Rental
                .SingleOrDefault(r => r.Id == id);

            if (rentalDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Rental, RentalDto>(rentalDto);
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            //if we use lot of condition block we make code pollution 


            // here was taken customer information according to Rental customerId
            var customer = _db.Customers
                .Single(c => c.Id == rentalDto.CustomerId);

            // Contains -->  select * from Movies Where MoviesId IN (1,2,3)
            var movies = _db.Movies
                .Where(m => rentalDto.MoviesId.Contains(m.Id));
         
            foreach (var movie in movies)
            {
                // here we checked Movie Stock Availability
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is Available.");
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _db.Rental.Add(rental);
            }

            _db.SaveChanges();

            return Ok();
        }
        
        [HttpPut]
        public IHttpActionResult UpdateRental(int id)
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            return Ok();
        }
      
    }
}