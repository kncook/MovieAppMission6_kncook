using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp_kncook.Models
    //this file sets up a connection between a database and program
    //inheriting from DbBase and from the base
{
    public class MovieEntriesContext : DbContext
    {
        //constructor // what we want to recieve(
        public MovieEntriesContext (DbContextOptions<MovieEntriesContext> options) : base (options)
        {

        }
        //USE dBSET to store the info //APP response is name of file
        public DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                //seeding data in the database
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Comedy",
                    Title = "Zoolander",
                    Year = 2001,
                    Director = "Ben Stiller",
                    Rating = "PG13",
                    Edited = true,
                    LentTo = "Luke",
                    Note = "so funny"
                },

                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "Drama/Adventure",
                    Title = "The Other Side of Heaven",
                    Year = 2001,
                    Director = "Mitch Davis",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "church",
                    Note = "inspirational"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Romance/Comedy",
                    Title = "The Proposal",
                    Year = 2009,
                    Director = "Anne Fletcher",
                    Rating = "PG13",
                    Edited = true,
                    LentTo = "Katherine",
                    Note = "My favorite movie"
                }
            );
        }
    }
}
