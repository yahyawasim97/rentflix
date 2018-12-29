using Rentflix.Dtos;
using Rentflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rentflix.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        ApplicationDbContext db;

        public NewRentalController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Id has been given");
            }
            var customer = db.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            
            if(customer == null)
            {
                return BadRequest("Invalid Customer");
            }

            
            var movies = db.Movies.Where(m =>  newRental.MovieIds.Contains(m.Id)).ToList();

            if(movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more movies are Invalid");
            }
            foreach (var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie Not Available");
                }
                movie.NumberAvailable--;
                Rental rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                db.Rental.Add(rental);
            }
            db.SaveChanges();
            return Ok();
          
        }
    }
}
