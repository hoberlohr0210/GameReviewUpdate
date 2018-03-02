﻿using GameReview.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Required]
        [Display(Name = "Review")]
        public string Review { get; set; }

        [Required]
        [Display(Name = "Rating 1-5")]
        public int Rating { get; set; }

        public List<SelectListItem> Games { get; set; }
        public AddReviewViewModel() { }

        public AddReviewViewModel(IEnumerable<ReviewGame> games)
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
