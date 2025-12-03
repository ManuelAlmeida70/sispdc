using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SisPDC.Models;

namespace SisPDC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
