using AutoMapper;
using Movietec.Data;
using Movietec.Models.DbModels;
using Movietec.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movietec.App.Controllers.WebApi
{
    public class MoviesController : ApiController
    {
        private MovietecContext context;

        public MoviesController()
        {
            this.context = new MovietecContext();
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = this.context.Movies.Find(id);
            if (movie == null)
                return this.NotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);

            return this.Ok(movieDto);
        }


        public IHttpActionResult GetMovies()
        {
            var moviesDtos = this.context.Movies.Select(Mapper.Map<Movie, MovieDto>).ToList();

            return this.Ok(moviesDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            this.context.Movies.Add(movie);
            this.context.SaveChanges();

            movieDto.Id = movie.Id;

            return this.Created(new Uri(this.Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            var movie = this.context.Movies.Find(id);
            if (movie == null)
                return this.NotFound();

            Mapper.Map(movieDto, movie);
            this.context.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = this.context.Movies.Find(id);
            if (movie == null)
                return this.NotFound();

            this.context.Movies.Remove(movie);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
