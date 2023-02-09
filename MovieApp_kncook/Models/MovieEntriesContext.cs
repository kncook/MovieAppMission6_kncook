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

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Comedy",
                    Title = "Zoolander",
                    Director = "Ben Stiller",
                    Rating = "PG13",
                    Edited = "yes",
                    LentTo = "Kat",
                    Note = "so funny"
                },

                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "Drama/Adventure",
                    Title = "The Other Side of Heaven",
                    Director = "Mitch Davis",
                    Rating = "PG",
                    Edited = "no",
                    LentTo = "church",
                    Note = "inspirational"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Romance/Comedy",
                    Title = "The Proposal",
                    Director = "Anne Fletcher",
                    Rating = "PG13",
                    Edited = "yes",
                    LentTo = "Katherine",
                    Note = "My favorite movie"
                }
            );
        }
    }
}
