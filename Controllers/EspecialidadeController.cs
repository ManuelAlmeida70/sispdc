using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SisPDC.Models.Entities;
using SisPDC.Services.Especialidade.Add;
using SisPDC.Services.Especialidade.DeleteById;
using SisPDC.Services.Especialidade.GerarRelatorioExcel;
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
            especialidade.DateTime = DateTime.Now;
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

        TempData["SuccessMessage"] = "Especialidade eliminado com sucesso!";
        return RedirectToAction("Listar");
    }

    [HttpPost]
    public async Task<IActionResult> Editar([FromServices] IUpdateEspecialidade useCase, EspecialidadeModel especialidadeModel)
    {
        if (ModelState.IsValid)
        {
            await useCase.Execute(especialidadeModel);
            TempData["SuccessMessage"] = "Especialidade alterada com sucesso!";
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

    public async Task<IActionResult> GerarRelatorioExcel([FromServices] IGerarRelatorioExcel useCase)
    {
        var tabela = await useCase.GerarRelatorio();

        using (XLWorkbook workbook = new XLWorkbook())
        {
            var ws = workbook.AddWorksheet(tabela, "Especialidade");

            ws.Columns("1").Width = 15;
            ws.Columns("2").Width = 25;
            ws.Columns("3").Width = 35;

            using(MemoryStream ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", $"especialidade{DateTime.Now.ToString("dd/MM/yyyy/")}.xls");
            }
        }
    }
}
