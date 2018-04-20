using GameReview.Models;
using GameReview.ViewModels;
using GameReviewUpdate.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameReview.Controllers
{
    [Authorize]
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext context;

        public TypeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
       
        [AllowAnonymous]
        public IActionResult Index()
        {
            var gameType = context.Types.ToList();
            return View(gameType);
        }

        public IActionResult Add()
        {
            AddTypeViewModel addTypeViewModel = new AddTypeViewModel();
            return View(addTypeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTypeViewModel addTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                GameType newType = new GameType
                {
                    Name = addTypeViewModel.Name

                };

                context.Types.Add(newType);
                context.SaveChanges();

                return Redirect("/Type");
            }

            return View(addTypeViewModel);
        }
    }
}