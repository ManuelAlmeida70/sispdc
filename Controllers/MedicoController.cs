using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SisPDC.DTOs;
using SisPDC.Models.Repositories;
using SisPDC.Services.Medico.Add;
using SisPDC.Services.Medico.EliminarById;
using SisPDC.Services.Medico.GetAll;
using SisPDC.Services.Medico.GetById;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class MedicoController : Controller
{

    private readonly IEspecialidadeRepository _especialidadeRepository;

    public MedicoController(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task<IActionResult> Listar([FromServices] IGetAllMedicos useCase)
    {
        var medicos = await useCase.Execute();
        return View(medicos);
    }

    [HttpGet]
    public async Task<IActionResult> CadastrarAsync()
    {
        var especialidades = await _especialidadeRepository.GetAll();

        ViewBag.Especialidades = new SelectList(
            especialidades,
            "Id",
            "Descricao"
        );
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Eliminar(string? id, [FromServices] IGetByIdMedico useCase)
    {
        var medico = await useCase.Execute(id);

        var medicoDTO = new PessoaClinicoEliminarDTO()
        {
            Cargo = medico.Cargo,
            IdClinico = medico.IdPessoaClinica,
            Nome = medico.Nome,
            IdEspecialidade = medico.IdEspecialidade.ToString(),
            IdUtilizador = medico.IdUtilizador,
            Email = medico.Email,
        };

        return View(medicoDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(PessoaClinicoEliminarDTO pessoaClinicoEliminarDTO, [FromServices] IEliminarByIdMedico useCase)
    {
        try
        {
            var result = await useCase.Execute(pessoaClinicoEliminarDTO);

            if (result == null)
            {
                TempData["ErrorMessage"] = "Erro ao eliminar médico. Verifique os dados e tente novamente.";
                return View(pessoaClinicoEliminarDTO);
            }

            TempData["SuccessMessage"] = "Médico eliminado com sucesso!";
            return RedirectToAction("Listar", "Medico");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro ao eliminar médico: {ex.Message}";
            return View(pessoaClinicoEliminarDTO);
        }
    }
    public IActionResult Editar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(PessoaClinicoDTO pessoaClinicoDTO, [FromServices] IAddMedico useCase)
    {
        if (ModelState.IsValid)
        {
            var result = await useCase.Execute(pessoaClinicoDTO);

            TempData["SuccessMessage"] = "Pessoa clinica cadastrado com sucesso";
            return RedirectToAction("Listar", "Medico");
        }
        return View(pessoaClinicoDTO);
    }
}
