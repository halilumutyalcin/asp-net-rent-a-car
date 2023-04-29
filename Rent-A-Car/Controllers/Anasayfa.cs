using Microsoft.AspNetCore.Mvc;

namespace Rent_A_Car.Controllers;

public class Anasayfa : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}