﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReview.Models;
using GameReview.ViewModels;
using GameReviewUpdate.Data;
using Microsoft.AspNetCore.Authorization;

namespace GameReview.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext context;

        public GameController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            IList<Game> games = context.Games.Include(g => g.Type).ToList();
            IList<Game> reviews = context.Games.Include(r => r.Review).ToList();

            return View(games);
        }

        public IActionResult Add()
        {

            AddGameViewModel addGameViewModel = new AddGameViewModel(context.Types.ToList());
            return View(addGameViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGameViewModel addGameViewModel)
        {
            if (ModelState.IsValid)
            {
                GameType newGameType = context.Types.Single(g => g.ID == addGameViewModel.TypeID);
                //add the new game to my existing games
                Game newGame = new Game
                {
                    Title = addGameViewModel.Title,
                    Description = addGameViewModel.Description,
                    Type = newGameType,
                    Players = addGameViewModel.Players
                };
                context.Games.Add(newGame);
                context.SaveChanges();

                return Redirect("/Game");
            }

            return View(addGameViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Games";
            ViewBag.games = context.Games.ToList();
            return View();

        }

        [HttpPost]
        public IActionResult Remove(int[] gameIds)
        {
            foreach (int gameId in gameIds)
            {
                Game theGame = context.Games.Single(g => g.ID == gameId);
                context.Games.Remove(theGame);
            }

            context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Type(int id)
        {
            if (id == 0)
            {
                return Redirect("/Type");
            }

            //will retrieve a specific genre that has its games list populated
            //that matches a given ID passed in by the administrative user
            GameType theType = context.Types
                .Include(ty => ty.Games)
                .Single(ty => ty.ID == id);

            ViewBag.title = "Games in type: " + theType.Name;
            //passes the list into the VIew
            //wouldn't have been populated if not included above
            //Games is a property we have already defined
            return View("Index", theType.Games);
        }

    }
}