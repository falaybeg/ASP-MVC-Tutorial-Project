using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamplesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int Stock { get;  set ; } 

        public Genre Genre { get; set; }

        [Display(Name="Genre Type")]
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }

    }
}