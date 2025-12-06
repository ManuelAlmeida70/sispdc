using Microsoft.AspNetCore.Mvc;

namespace SisPDC.Controllers;
public class HomeUtenteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
