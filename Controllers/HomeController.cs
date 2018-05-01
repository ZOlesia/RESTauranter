using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
       private RestaurantContext _context;
 
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpPost]
        [Route("post/review")]
        public IActionResult AddReview(Restaurant newReview)
        {
            if (ModelState.IsValid)
            {
                if(newReview.visit_date > DateTime.Today)
                {
                    TempData["error"] = "Date of visit cannot be in the future";
                    return View("Index");
                }
                // newReview.created_at = DateTime.Now;
                // newReview.updated_at = DateTime.Now;
                _context.restaurants.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("AllReviews");
            }
            
            return View("Index");
        }


        [HttpGet]
        [Route("review")]
        public IActionResult AllReviews()
        {
            List<Restaurant> allReviews = _context.restaurants.OrderBy(c => c.created_at).ToList();
            allReviews.Reverse();
            ViewBag.AllReviews = allReviews;
            return View("About");
        }
    }
}
