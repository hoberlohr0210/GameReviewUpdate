using GameReview.Models;
using GameReview.ViewModels;
using GameReviewUpdate.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReviewController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            var reviewGame = context.Reviews.ToList();
            return View(reviewGame);
        }

        public IActionResult Add()
        {
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel();
            return View(addReviewViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddReviewViewModel addReviewViewModel)
        {
            if(ModelState.IsValid)
            {
                ReviewGame newReview = new ReviewGame
                {
                    Name = addReviewViewModel.Name,
                    Review = addReviewViewModel.Review,
                    Rating = addReviewViewModel.Rating
                };

                context.Reviews.Add(newReview);
                context.SaveChanges();

                return Redirect("/Review");
            }

            return View(addReviewViewModel);
        }
    }
}
