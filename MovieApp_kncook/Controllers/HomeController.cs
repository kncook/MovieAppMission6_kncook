using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieApp_kncook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp_kncook.Controllers
{   
    
    public class HomeController : Controller
    {
      
        private MovieEntriesContext MovieContext { get; set; } // _= private, my fle does not have that tho? is that ok?
        //constructor
        
        public HomeController(MovieEntriesContext tempName)
        {

            MovieContext = tempName;
        }
        /*directs to the home/index page*/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieApplication (ApplicationResponse ar)
        {/*model needs to be valid in order to return the confirmation page*/
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View();
            }
            /*W/o the "confirmation" you would just stay on that page with data still in the boxes*/
            /*passing ar aalows for you to pull the movie title, category, etc.*/
        }

        /*directs to the adding a movie page*/
        [HttpGet]
        public IActionResult MovieApplication()
        {
            /*this variable holds this list of categories and pulls the table in and stored in the obj ViewBag*/
            ViewBag.Categories =  MovieContext.Categories.ToList();

            return View();
          
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TableData ()
        {
            /*find, single (ull single record) you can selct, orderby or where*/
            /*lambda x=> is creating an anomonyous function*/
            var applications = MovieContext.Responses
                /*This will allow you to refernece the category name insted of ID i the table data*/
                .Include(x => x.Category )
                /*these are to filter: only shows you it where movie is edited*/
                /*.Where(x => x.Edited == true)*/
                .OrderBy(x => x.Title)
                .ToList();
            /*can also name MovieApplication something different as LONG as you put the file name in quotes in the View(*/
            return View(applications);
            /*putting it in a list and passing it to the view to be able to display the data*/
        }

        [HttpGet]
        /*This will allow them to edit their response by taking them to the same html page we already made*/
        public IActionResult Edit (int applicationid) //
        {
            ViewBag.Categories = MovieContext.Categories.ToList();
            var application = MovieContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View("MovieApplication", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
           
            MovieContext.Update(ar); //this updates changes based on what was passed in to the applicationresponse
            MovieContext.SaveChanges();

            return RedirectToAction("TableData");

        }
        //These are for deleting a movie
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = MovieContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            MovieContext.Responses.Remove(ar);
            MovieContext.SaveChanges();
            return RedirectToAction("TableData");
        }
    }

}
