using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnimalsWeb.Models;

namespace AnimalsWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("An error occurred: " + Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        return View(new ErrorModel { Requested = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}