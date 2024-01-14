using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie_App.Models
{
    public class db_movieEntities : DbContext
    {
        public DbSet<Movie> tb_movies { get; set; }
        public DbSet<Categories> tb_Categories { get; set; }
    }
}