using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SisPDC.Controllers;

[Authorize(Roles = "Clinico")]
public class HomePessoaClinicaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
