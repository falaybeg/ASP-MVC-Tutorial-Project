using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamplesApp.DTOs
{
    public class RentalDto
    {
    
        public int CustomerId { get; set; }
        public List<int> MoviesId { get; set; }
    }
}