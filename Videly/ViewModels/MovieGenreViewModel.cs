using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videly.Models;

namespace Videly.ViewModels
{
    public class MovieGenreViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genre { get; set; }
    }
}