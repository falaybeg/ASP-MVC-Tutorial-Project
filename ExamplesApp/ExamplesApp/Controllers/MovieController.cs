using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ExamplesApp.ViewModel;

namespace ExamplesApp.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _db;

        public MovieController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Movie
        public ViewResult Index()
        {
            //var movies = _db.Movies.Include(m => m.Genre).ToList();

            // we checked if user is admin canManageMovies 
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _db.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                 Genre = genre
            };
            return View("New",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _db.Genre.ToList()
                };

                return View("New", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _db.Movies.Add(movie);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult EditMovie(int id)
        {
            var movie = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _db.Genre.ToList()
            };

            return View("New", viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _db.Movies.Include(g=>g.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

    }
}