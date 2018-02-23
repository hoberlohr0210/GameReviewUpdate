﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GameReviewUpdate.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
