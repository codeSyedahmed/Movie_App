using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movie_App.Models
{
    public class Movie
    {
        [Key]
        public int movie_id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int? cat_id { get; set; }
        [ForeignKey("cat_id")]
        public virtual Categories Categories { get; set; }
    }
}