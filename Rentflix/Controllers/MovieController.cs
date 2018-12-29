using Rentflix.Models;
using Rentflix.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentflix.Controllers
{
    
    public class MovieController : Controller
    {
        ApplicationDbContext db;
        public MovieController()
        {
            db = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Movie
        
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
            {
                return View("List");
            }

            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Details(int id)
        {
            var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var genres = db.Genres.ToList();
            var viewModelMovie = new MovieFormViewModel(new Movie())
            {   
                Genres = genres
            };
            return View("MovieForm", viewModelMovie);

        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = db.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Save(Movie movie)
        {
            string fileName = Path.GetFileNameWithoutExtension(movie.MovieImageFile.FileName) ;
            string extension = Path.GetExtension(movie.MovieImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff")+ extension;
            movie.MovieImage =  fileName;
            fileName = Path.Combine(Server.MapPath("~/MovieImages/"),fileName);
            movie.MovieImageFile.SaveAs(fileName);
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres = db.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberAvailable = movie.NumberAvailable;
                movieInDb.MovieImage = movie.MovieImage;
                movieInDb.MovieImageFile = movie.MovieImageFile;
                movieInDb.trailerUrl = movie.trailerUrl;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}