using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SisPDC.Controllers;

[Authorize(Roles = "Utente")]
public class HomeUtenteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult MarcarConsultaUtente()
    {
        return View("~/Views/MarcarConsultaUtente/MarcarConsultaUtente.cshtml");
    }
}
