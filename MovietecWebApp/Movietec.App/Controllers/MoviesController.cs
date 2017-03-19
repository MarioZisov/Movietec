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
            return this.View("MovieForm");
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                this.context.Movies.Add(movie);
            }
            else
            {
                var dbMovie = this.context.Movies.First(m => m.Id == movie.Id);
                dbMovie.Title = movie.Title;
                dbMovie.Genre = movie.Genre;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.NumberInStock = movie.NumberInStock;
            }

            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public ActionResult Edit(int id)
        {
            var movie = this.context.Movies.Find(id);
            if (movie == null)
                return this.HttpNotFound();

            return View("MovieForm", movie);
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