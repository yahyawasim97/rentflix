using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentflix.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberAvailable { get; set; }
        [Required]
        public GenreDto Genre { get; set; }
        public byte? GenreId { get; set; }
        public string MovieImage { get; set; }
        public string trailerUrl { get; set; }
    }
}