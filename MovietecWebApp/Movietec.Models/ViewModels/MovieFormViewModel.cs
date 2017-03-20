using Movietec.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movietec.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            this.Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.GenreId = movie.GenreId;
            this.NumberInStock = movie.NumberInStock;
            this.ReleaseDate = movie.ReleaseDate;
        }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
