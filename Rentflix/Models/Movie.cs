using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentflix.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int NumberAvailable { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
        [Display(Name="Trailer Url")]
        [Required]
        public string trailerUrl { get; set; }
        [Display(Name = "Movie Image")]
        public string MovieImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase MovieImageFile { get;set; }
    }
}