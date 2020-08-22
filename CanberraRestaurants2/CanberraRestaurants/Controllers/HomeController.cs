using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CanberraRestaurants.Data;
using Microsoft.EntityFrameworkCore;


namespace CanberraRestaurants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Restaurants()
        {
            return View();
        }

        public async Task<IActionResult> Cuisine()
        {
            var allResults = from result in _context.Review
                            orderby result.Date descending
                            select result;


            return View(await allResults.ToListAsync());
        }

        public IActionResult Dishes()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        /*public IActionResult Reviews() /*from home controller - new reviews page uses reviews controller
        {
            return View();
        }*/

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
