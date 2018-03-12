using GameReview.Models;
using GameReview.ViewModels;
using GameReviewUpdate.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameReview.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReviewController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            IList<ReviewGame> reviews = context.Reviews.Include(r => r.Game).ToList();
            return View(reviews);
        }

        public IActionResult Add()
        {
            IEnumerable<Game> games = context.Games.ToList();
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel(games);
            return View(addReviewViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddReviewViewModel addReviewViewModel)
        {
            if(ModelState.IsValid)
            {
                Game newGame = context.Games.Single(g => g.ID == addReviewViewModel.GameID);

                ReviewGame newReview = new ReviewGame
                {
                    Review = addReviewViewModel.Review,
                    Rating = addReviewViewModel.Rating,
                    Game = newGame
                };

                context.Reviews.Add(newReview);
                context.SaveChanges();

                return Redirect("/Review");
            }

            return View(addReviewViewModel);
        }
    }
}
