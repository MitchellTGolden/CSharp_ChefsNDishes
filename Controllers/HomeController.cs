using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using ChefsNDishes.Context;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ChefList = _context.Chefs.Include(d => d.DishList)
            .ToList();
            return View();
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.DishList = _context.Dishes.Include(d => d.Creator)
            .ToList();
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.ChefList = _context.Chefs
            .ToList();
            return View();
        }

        [HttpPost("newChef")]
        public IActionResult NewChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpPost("create/new/dish")]
        public IActionResult CreateNewDish(Dish NewDish)
        {
            if (ModelState.IsValid)
            {
                // NewDish.Creator = _context.Chefs.FirstOrDefault(c => c.ChefId == NewDish.ChefId);
                _context.Dishes.Add(NewDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.ChefList = _context.Chefs
                .ToList();
                return View("NewDish");
            }
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
