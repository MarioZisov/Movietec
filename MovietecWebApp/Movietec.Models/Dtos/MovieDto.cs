using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movietec.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        //[Range(1, 20)]
        public int NumberInStock { get; set; }

        public int GenreId { get; set; }
    }
}
