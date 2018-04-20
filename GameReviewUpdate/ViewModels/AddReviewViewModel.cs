using GameReview.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReview.ViewModels
{
    public class AddReviewViewModel
    {
        [Required]
        [Display(Name = "Game Title")]
        public int GameID { get; set; }

        //[Required]
        //[Display(Name = "Name of Game")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Review must not be left blank.")]
        [Display(Name = "Review")]
        public string Review { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        public List<SelectListItem> Games { get; set; }
        public AddReviewViewModel() { }

        public AddReviewViewModel(IEnumerable<Game> games)
        {
            Games = new List<SelectListItem>();
            foreach (var game in games)
            {
                Games.Add(new SelectListItem
                {
                    Value = (game.ID).ToString(),
                    Text = game.Title
                });
            }
        }
    }
}
