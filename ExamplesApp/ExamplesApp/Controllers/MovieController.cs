using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ExamplesApp.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _db;

        public MovieController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _db.Movies.Include(m => m.Genre).ToList();

            return View(movies);
          
        }

        protected override void Dispose(bool disposing)
        {
           _db.Dispose();
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