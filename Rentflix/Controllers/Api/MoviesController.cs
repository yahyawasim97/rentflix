using AutoMapper;
using Rentflix.Dtos;
using Rentflix.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rentflix.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            db = new ApplicationDbContext();
        }
        //GET api/movies
        [Authorize]
        public IHttpActionResult GetMovies(string query= null)
        {

            var moviesQuery = db.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            return Ok(moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }
        //GET api/movies/1
        
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.Single(m => m.Id == id);
            if (movie == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            db.Movies.Add(movie);
            movieDto.Id = movie.Id;

            db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(movieDto, movieInDb);
            db.SaveChanges();

        }

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Movies.Remove(movieInDB);
            db.SaveChanges();

        }
    }

}
