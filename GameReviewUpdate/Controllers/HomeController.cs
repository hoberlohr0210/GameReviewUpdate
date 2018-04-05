using GameReviewUpdate.Data;
using GameReviewUpdate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewUpdate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var games = from g in context.Games
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Title.Contains(searchString));
            }
            return View(await games.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is a website where you can read about board games.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
