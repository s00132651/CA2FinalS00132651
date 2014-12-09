using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{

    public class Movie
    {
        public int MovieId { get; set; }
        [Display(Name = "Movie Name"), Required]
        public string Name { get; set; }
        [Display(Name = "Box Office"), Required]
        public int BoxOffice { get; set; }
        public string Description { get; set; }
        public virtual List<ScreenNames> Actors { get; set; }


    }

    public class ScreenNames
    {
        [Key, Column(Order = 0)]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Key, Column(Order = 1)]
        public int ActorId { get; set; }
   
        public virtual Actor Actor { get; set; }
        [Display(Name = "Screen Name"), Required]
        public string ScreenName { get; set; }
    }

    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public int Age { get; set; }
        public virtual List<ScreenNames> Movies { get; set; }
    }

   public  class CinemaDB : DbContext
    {
        public CinemaDB()
            : base("name=CinemaDB")
        { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ScreenNames> ScreenNames { get; set; }


    }
}