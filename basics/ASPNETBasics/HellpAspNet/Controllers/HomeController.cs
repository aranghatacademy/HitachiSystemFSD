using System;
using Microsoft.AspNetCore.Mvc;

namespace HellpAspNet.Controllers;

//This is a controller class
[Route("")]
public class HomeController : Controller
{
     //Action Method
     public IActionResult Index()
     {
          return View();
     }
}
