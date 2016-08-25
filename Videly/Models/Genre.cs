using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videly.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string GenreType { get; set; }

    }
}