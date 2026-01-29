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
    public  DbSet<PessoaAdministrativaModel> PessoaAdministrativas { get; set; }
    public  DbSet<PessoaClinicaModel> PessoaClinicas { get; set; }
    public  DbSet<ConsultaModel> Consultas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da entidade Consulta
        modelBuilder.Entity<ConsultaModel>(entity =>
        {
            // Chave primária
            entity.HasKey(e => e.IdConsulta);

            // Propriedades obrigatórias
            entity.Property(e => e.IdUtente).IsRequired();
            entity.Property(e => e.DataConsulta).IsRequired();
            entity.Property(e => e.HoraConsulta).IsRequired();
            entity.Property(e => e.Estado).IsRequired().HasDefaultValue("Pendente");
            entity.Property(e => e.DataCriacao).IsRequired();

            // Relacionamentos
            entity.HasOne(e => e.Utente)
                .WithMany()
                .HasForeignKey(e => e.IdUtente)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.PessoaClinica)
                .WithMany()
                .HasForeignKey(e => e.IdPessoaClinica)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para performance
            entity.HasIndex(e => e.IdUtente);
            entity.HasIndex(e => e.IdPessoaClinica);
            entity.HasIndex(e => e.DataConsulta);
            entity.HasIndex(e => e.Estado);
        });
    }
}
