using Movietec.Data;
using Movietec.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movietec.App.Controllers
{
    public class MoviesController : Controller
    {
        private MovietecContext context;

        public MoviesController()
        {
            this.context = new MovietecContext();
        }

        public ActionResult All()
        {
            var movies = this.context.Movies.ToList();
            return this.View(movies);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            return RedirectToAction("All");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return this.HttpNotFound();

            var movies = this.context.Movies.ToList();
            if (!movies.Any(m => m.Id == id))
                return this.HttpNotFound();

            var movie = movies.First(m => m.Id == id);
            return this.View(movie);
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
        }
    }
}