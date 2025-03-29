using System;
using Microsoft.AspNetCore.Mvc;

namespace HellpAspNet.Controllers;

//This is a controller class

public class CityAndCountry
{
     public List<string>  Cities {get; set;}
     public List<string> Countries {get; set;}
}


public class HomeController : Controller
{
     CityAndCountry cityAndCountry = new CityAndCountry();
    
    public HomeController()
    {
         cityAndCountry.Cities = new List<string>(){"New York", "Los Angeles", "Chicago", "Houston", "Miami"};
         cityAndCountry.Countries = new List<string>(){"USA", "Canada", "Mexico", "Brazil", "Argentina"};
    }

     //Action Method
     public IActionResult Index()
     {
         
          //Sent as apart of a ViewBag
          //Sent as a Model
          ViewBag.Title = "Hello ASP.NET";
          ViewBag.Message = "Welcome to ASP.NET";
          return View(cityAndCountry);
     }


     public IActionResult ContactUsHere()
     {
          return View();
     }
}
