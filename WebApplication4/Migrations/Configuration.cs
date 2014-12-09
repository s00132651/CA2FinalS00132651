namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication4.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication4.Models.CinemaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication4.Models.CinemaDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Movies.AddOrUpdate(m => m.Name,
            new Movie { MovieId = 1, Name = "Drive", BoxOffice = 76000000, Description = "nothing" },
            new Movie { MovieId = 2, Name = "Batman", BoxOffice = 200000, Description = "nothing" },
            new Movie { MovieId = 3, Name = "The Dark Knight", BoxOffice = 1000000, Description = "nothing" },
            new Movie { MovieId = 4, Name = "Iron Man", BoxOffice = 1000000, Description = "nothing" },
            new Movie { MovieId = 5, Name = "The Avengers", BoxOffice = 1000000, Description = "nothing" }
            );

            context.Actors.AddOrUpdate(a => a.Name,
                new Actor { ActorId = 1, Name = "Ryan Gosling", Age = 34, Bio = "nothing" },
                new Actor { ActorId = 2, Name = "Christian Bale", Age = 40, Bio = "nothing" },
                new Actor { ActorId = 3, Name = "Gary Oldman", Age = 56, Bio = "nothing" },
                new Actor { ActorId = 4, Name = "Robert Downey Jr", Age = 49, Bio = "nothing" },
                new Actor { ActorId = 5, Name = "Samuel L Jackson", Age = 65, Bio = "nothing" },
                new Actor { ActorId = 6, Name = "Brian Cranston", Age = 58, Bio = "nothing" },
                new Actor { ActorId = 7, Name = "Liam Neeson", Age = 62, Bio = "nothing" },
                new Actor { ActorId = 8, Name = "Michael Caine", Age = 81, Bio = "nothing" },
                new Actor { ActorId = 9, Name = "Gwyneth Paltrow", Age = 42, Bio = "nothing" },
                new Actor { ActorId = 10, Name = "Scarlet Johansson ", Age = 30, Bio = "nothing" }

                );


            context.ScreenNames.AddOrUpdate(s => s.ScreenName,
           new ScreenNames { MovieId = 1, ActorId = 1, ScreenName = "The Driver" },
           new ScreenNames { MovieId = 2, ActorId = 2, ScreenName = "Bruce Wayne" },
           new ScreenNames { MovieId = 2, ActorId = 3, ScreenName = "Commisioner Gordon" },
           new ScreenNames { MovieId = 2, ActorId = 8, ScreenName = "Alfred" },
           new ScreenNames { MovieId = 2, ActorId = 7, ScreenName = "Raas Al Gul" });

        }
    }
}
