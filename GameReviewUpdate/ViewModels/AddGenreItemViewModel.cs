﻿using GameReview.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameReview.ViewModels
{
    public class AddGenreItemViewModel
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }

        public Genre Genre { get; set; }
        public List<SelectListItem> Games { get; set; }

        public AddGenreItemViewModel() { }

        public AddGenreItemViewModel(Genre genre, IEnumerable<Game> games)
        {
            Games = new List<SelectListItem>();

            foreach (var game in games)
            {
                Games.Add(new SelectListItem
                {
                    Value = game.ID.ToString(),
                    Text = game.Title
                });
            }

            Genre = genre;
        }
    }
}
