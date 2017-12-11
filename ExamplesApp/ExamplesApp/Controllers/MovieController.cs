using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamplesApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = GetMovie();
            return View(movie.ToList());
        }
            
        public IEnumerable<Movie> GetMovie()
        {
            return new List<Movie>()
            {
                new Movie {Name ="Shrek"},
                new Movie {Name ="Batman "}
            };
        }
     
    }
}