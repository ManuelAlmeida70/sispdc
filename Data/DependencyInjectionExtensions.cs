using Microsoft.EntityFrameworkCore;
using SisPDC.Data.Repositories;
using SisPDC.Models.Repositories;

namespace SisPDC.Data;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositorires(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositorires(IServiceCollection services)
    {
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        services.AddScoped<IUtenteRepository, UtenteRepository>();
        services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 43));

        services.AddDbContext<DbSisPdcContext>(options => options.UseMySql(connectionString, serverVersion));
    }
}
