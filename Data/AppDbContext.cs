using Microsoft.EntityFrameworkCore;
using c_sharp_odontoprev.Models;

namespace c_sharp_odontoprev.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Bairro> Bairros{ get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Unidade> Unidades{ get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.IdEstado)
                .HasConstraintName("FK_ESTADO")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bairro>()
                .HasOne(b => b.Cidade)
                .WithMany()
                .HasForeignKey(b => b.IdCidade)
                .HasConstraintName("FK_CIDADE")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Bairro)
                .WithMany()
                .HasForeignKey(e => e.IdBairro)
                .HasConstraintName("FK_BAIRRO")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Genero)
                .WithMany() 
                .HasForeignKey(p => p.IdGenero)
                .HasConstraintName("FK_GENERO_PACIENTE") 
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Dentista>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.IdGenero)
                .HasConstraintName("FK_GENERO_DENTISTA")
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
