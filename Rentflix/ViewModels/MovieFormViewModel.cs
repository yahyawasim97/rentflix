using Rentflix.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentflix.ViewModels
{
    public class MovieFormViewModel
    {
        
        [NotMapped]
        public HttpPostedFileBase MovieImageFile { get; set; }
        [Display(Name = "Movie Image")]
        public string MovieImage { get; set; }
        public IEnumerable<Genre> Genres{ get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberAvailable { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
        [Display(Name = "Trailer Url")]
        [Required]
        public string trailerUrl { get; set; }
        public string Title
        {
            get
            {
                return Id == 0 ? "New Movie" : "Edit Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberAvailable = movie.NumberAvailable;
            GenreId = movie.GenreId;
            MovieImage = movie.MovieImage;
            MovieImageFile = movie.MovieImageFile;
            trailerUrl = movie.trailerUrl;
        }
    }
    
}