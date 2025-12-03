using Microsoft.AspNetCore.Mvc;
using SisPDC.Models.Entities;
using SisPDC.Services.Especialidade.Add;
using SisPDC.Services.Especialidade.DeleteById;
using SisPDC.Services.Especialidade.GetAll;
using SisPDC.Services.Especialidade.GetById;
using SisPDC.Services.Especialidade.Update;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class EspecialidadeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Criar(EspecialidadeModel especialidade, [FromServices] IAddEspecialidade useCase)
    {
        if (ModelState.IsValid)
        {
            await useCase.Execute(especialidade);

            TempData["SuccessMessage"] = "Especialidade criada com sucesso!";

            return RedirectToAction("Listar");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Eliminar(int? id, [FromServices] IGetByIdEspecialidade useCase)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }

        var especialidade = await useCase.Execute(id);

        if (especialidade is null)
        {
            return NotFound();
        }
        return View(especialidade);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(EspecialidadeModel especialidadeModel, [FromServices] IDeleteByIdEspecialidade useCase)
    {
        if (especialidadeModel is null)
        {
            return NotFound();
        }

        await useCase.Execute(especialidadeModel);

        return RedirectToAction("Listar");
    }

    [HttpPost]
    public async Task<IActionResult> Editar([FromServices] IUpdateEspecialidade useCase, EspecialidadeModel especialidadeModel)
    {
        if (ModelState.IsValid)
        {
            await useCase.Execute(especialidadeModel);
            return RedirectToAction("Listar");
        }
        return View(especialidadeModel);
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int? id, [FromServices] IGetByIdEspecialidade useCase)
    {
        if (id == null || id == 0)
            return NotFound();

        var especialidade = await useCase.Execute(id);

        if (especialidade == null)
        {
            return NotFound();
        }

        return View(especialidade);
    }

    public async Task<IActionResult> Listar(
        [FromServices] IGetAllEspecialidade useCase)
    {
        var especialidades = await useCase.Execute();

        return View(especialidades);
    }
}
