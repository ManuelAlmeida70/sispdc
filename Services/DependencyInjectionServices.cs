using SisPDC.Services.Especialidade.Add;
using SisPDC.Services.Especialidade.DeleteById;
using SisPDC.Services.Especialidade.GetAll;
using SisPDC.Services.Especialidade.GetById;
using SisPDC.Services.Especialidade.Update;

namespace SisPDC.Services;

public static class DependencyInjectionServices
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    public static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IAddEspecialidade, AddEspecialidade>();
        services.AddScoped<IGetAllEspecialidade, GetAllEspecialidade>();
        services.AddScoped<IGetByIdEspecialidade, GetByIdEspecialidade>();
        services.AddScoped<IUpdateEspecialidade, UpdateEspecialidade>();
        services.AddScoped<IDeleteByIdEspecialidade, DeleteByIdEspecialidade>();
    }
}
