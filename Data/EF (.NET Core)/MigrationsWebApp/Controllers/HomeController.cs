﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MigrationsWebApp.Models;

namespace MigrationsWebApp.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index() => View();

      public IActionResult About()
      {
         ViewData["Message"] = "Your application description page.";

         return View();
      }

      public IActionResult Contact()
      {
         ViewData["Message"] = "Your contact page.";

         return View();
      }

      public IActionResult Error() => View(new ErrorViewModel
         {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
   }
}