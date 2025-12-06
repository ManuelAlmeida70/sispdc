using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;

namespace SisPDC.Data;

public class DbSisPdcContext : DbContext
{
    public DbSisPdcContext(DbContextOptions<DbSisPdcContext> options) : base(options)
    {
        
    }

    public DbSet<EspecialidadeModel> Especialidades { get; set; }
    public DbSet<UtilizadorModel> Utilizadores { get; set; }
    public  DbSet<PessoaAdministrativaModel> PessoaAdministrativas { get; set; }
    public  DbSet<PessoaClinicaModel> PessoaClinicas { get; set; }
    public  DbSet<UtenteModel> utentes { get; set; }
}
