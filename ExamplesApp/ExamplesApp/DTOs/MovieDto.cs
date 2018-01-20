using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamplesApp.DTOs
{
    public class MovieDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int Stock { get; set; }

        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }
        public int NumberAvailable { get; set; }


    }
}