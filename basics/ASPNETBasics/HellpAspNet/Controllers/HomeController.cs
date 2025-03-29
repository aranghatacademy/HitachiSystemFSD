using System;
using Microsoft.AspNetCore.Mvc;

namespace HellpAspNet.Controllers;

//This is a controller class

public class HomeController : Controller
{
     List<string> cities = new List<string>(){"New York", "Los Angeles", "Chicago", "Houston", "Miami"};
     //Action Method
     public IActionResult Index()
     {
         
          //Sent as apart of a ViewBag
          //Sent as a Model
          ViewBag.Title = "Hello ASP.NET";
          ViewBag.Message = "Welcome to ASP.NET";
          return View(cities);
     }


     public IActionResult ContactUsHere()
     {
          return View();
     }
}
