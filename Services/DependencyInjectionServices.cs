using SisPDC.AutoMapper;
using SisPDC.Data.Repositories;
using SisPDC.Models.Repositories;
using SisPDC.Services.Administrativa.Add;
using SisPDC.Services.Administrativa.GerarNumeroAdministrativo;
using SisPDC.Services.Administrativa.GetAll;
using SisPDC.Services.Consulta.Add;
using SisPDC.Services.Consulta.AtribuirMedico;
using SisPDC.Services.Consulta.GetAll;
using SisPDC.Services.Consulta.GetById;
using SisPDC.Services.CriptPassword;
using SisPDC.Services.Especialidade.Add;
using SisPDC.Services.Especialidade.DeleteById;
using SisPDC.Services.Especialidade.GerarRelatorioExcel;
using SisPDC.Services.Especialidade.GetAll;
using SisPDC.Services.Especialidade.GetById;
using SisPDC.Services.Especialidade.Update;
using SisPDC.Services.Exames.Add;
using SisPDC.Services.Exames.GetAll;
using SisPDC.Services.Medico.Add;
using SisPDC.Services.Medico.EliminarById;
using SisPDC.Services.Medico.GerarNumeroMedico;
using SisPDC.Services.Medico.GetAll;
using SisPDC.Services.Medico.GetById;
using SisPDC.Services.Utente.Add;
using SisPDC.Services.Utente.GerarNumeroUtente;
using SisPDC.Services.Utente.GetUtenteNumero;
using SisPDC.Services.Utilizador.VerificarSessao;
using SisPDC.Services.Utilizador.VerifyEmail;

namespace SisPDC.Services;

public static class DependencyInjectionServices
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    public static void AddUseCases(IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IPessoaClinicaRepository, PessoaClinicaRepository>();
        services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();

        //Scoped
        services.AddScoped<IAddEspecialidade, AddEspecialidade>();
        services.AddScoped<IGetAllEspecialidade, GetAllEspecialidade>();
        services.AddScoped<IGetByIdEspecialidade, GetByIdEspecialidade>();
        services.AddScoped<IUpdateEspecialidade, UpdateEspecialidade>();
        services.AddScoped<IDeleteByIdEspecialidade, DeleteByIdEspecialidade>();
        services.AddScoped<IGerarRelatorioExcel, GerarRelatorioExcel>();

        //Utente
        services.AddScoped<IAddUtente, AddUtente>();
        services.AddScoped<IGerarNumeroUtente, GerarNumeroUtente>();
        services.AddScoped<IGetUtenteNumero, GetUtenteNumero>();

        //Email
        services.AddScoped<IVerifyEmail, VerifyEmail>();
        services.AddScoped<IVerificarSessao, VerificarSessao>();

        //Medico
        services.AddScoped<IGerarNumeroMedico, GerarNumeroMedico>();
        services.AddScoped<IAddMedico, AddMedico>();
        services.AddScoped<IGetAllMedicos, GetAllMedicos>();
        services.AddScoped<IGetByIdMedico, GetByIdMedico>();
        services.AddScoped<IEliminarByIdMedico, EliminarByIdMedico>();

        //Consulta
        services.AddScoped<IAddConsulta, AddConsulta>();
        services.AddScoped<IGetAllConsulta, GetAllConsulta>();
        services.AddScoped<IGetConsultaById, GetConsultaById>();
        services.AddScoped<IAtribuirConsultaMedico, AtribuirConsultaMedico>();


        //Administrativa
        services.AddScoped<IAddAdministrativa, AddAdministrativa>();
        services.AddScoped<IGerarNumeroAdministrativo, GerarNumeroAdministrativo>();
        services.AddScoped<IGetAllAdministrativa, GetAllAdministrativa>();

        //Palavra-passe
        services.AddScoped<ICriptPassword, CriptPassworded>();

        //Exame
        services.AddScoped<IAddExame, AddExame>();
        services.AddScoped<IGetAllExame, GetAllExame>();

        //Singleton
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    }
}
