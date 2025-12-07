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
    public  DbSet<UtenteModel> Utentes { get; set; }
}
