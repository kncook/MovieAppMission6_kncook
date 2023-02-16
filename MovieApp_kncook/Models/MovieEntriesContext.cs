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
        //queries out and pulls the data
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        { //will list out all the categories
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }

                );
            

            mb.Entity<ApplicationResponse>().HasData(
                //seeding data in the database
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 2,
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
                    CategoryId = 4,
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
                    CategoryId = 2,
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
