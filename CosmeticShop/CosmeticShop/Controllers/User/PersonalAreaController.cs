﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Controllers
{
    public class PersonalAreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PersonalData() => View();
        
    }
}