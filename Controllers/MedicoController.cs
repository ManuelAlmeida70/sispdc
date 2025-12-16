using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;

namespace SisPDC.Controllers;
public class MedicoController : Controller
{
    public IActionResult Listar()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }
    public IActionResult Eliminar()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(PessoaClinicoDTO pessoaClinicoDTO)
    {
        if (ModelState.IsValid)
        {
            // Lógica para salvar os dados do médico
            return RedirectToAction("Listar", "Medico");
        }
        return View(pessoaClinicoDTO);
    }
}
