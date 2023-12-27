using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bol;
using DALconnet;
using Riderpoint.Models;
using System.Collections.Generic;

namespace Riderpoint.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Rider r1 = new Rider{Rider_Id=1,Name="Rohit",Mobile_no="4637",Address="Pune"};
        // Rider r2 = new Rider{Rider_Id=2,Name="Anshu",Mobile_no="465537",Address="Bhopal"};
        // List<Rider> ls=new List<Rider>();
        // ls.Add(r1);
        // ls.Add(r2);

        DBManager db=new DBManager();
        List<Rider> ls=DBManager.GetAllRiders();

        ViewData["Riders"]=ls;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
