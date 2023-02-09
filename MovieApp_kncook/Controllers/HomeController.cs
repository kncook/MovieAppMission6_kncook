using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieEntriesContext MovieEntriesContext { get; set; } // _= private, my fle does not have that tho? is that ok?
        //constructor
        public HomeController(ILogger<HomeController> logger, MovieEntriesContext tempName)
        {
            _logger = logger;
            MovieEntriesContext = tempName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieApplication()
        {
            /*can also name MovieApplication something different as LONG as you put the file name in quotes in the View(*/
            return View();
        }

        [HttpPost]
        public IActionResult MovieApplication (ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                MovieEntriesContext.Add(ar);
                MovieEntriesContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                return View();
            }
            /*W/o the "confirmation" you would just stay on that page with data still in the boxes*/
            /*passing ar aalows for you to pull the movie title, category, etc.*/
        }

        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
