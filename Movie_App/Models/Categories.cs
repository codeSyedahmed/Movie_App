using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_App.Models
{
    public class Categories
    {
        [Key]
        public int catagory_id { get; set; }
        public string name { get; set; }
    }
}