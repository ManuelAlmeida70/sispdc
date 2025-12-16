using SisPDC.Services.CriptPassword;
using SisPDC.Services.Especialidade.Add;
using SisPDC.Services.Especialidade.DeleteById;
using SisPDC.Services.Especialidade.GerarRelatorioExcel;
using SisPDC.Services.Especialidade.GetAll;
using SisPDC.Services.Especialidade.GetById;
using SisPDC.Services.Especialidade.Update;
using SisPDC.Services.Medico.Add;
using SisPDC.Services.Medico.GerarNumeroMedico;
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
    }

    public static void AddUseCases(IServiceCollection services)
    {
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


        services.AddScoped<ICriptPassword, CriptPassworded>();

        //Singleton
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    }
}
