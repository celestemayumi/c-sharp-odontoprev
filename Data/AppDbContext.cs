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

            // Paciente

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.IdGenero)
                .HasConstraintName("FK_GENERO_PACIENTE")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco)
                .HasConstraintName("FK_ENDERECO_PACIENTE")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Login)
                .WithOne()
                .HasForeignKey<Paciente>(p => p.IdLogin)
                .HasConstraintName("FK_LOGIN_PACIENTE")
                .IsRequired();

            // Dentista

            modelBuilder.Entity<Dentista>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.IdGenero)
                .HasConstraintName("FK_GENERO_DENTISTA")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Dentista>()
                .HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco)
                .HasConstraintName("FK_ENDERECO_DENTISTA")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Dentista>()
                .HasOne(d => d.Login) 
                .WithOne() 
                .HasForeignKey<Dentista>(d => d.IdLogin)
                .HasConstraintName("FK_LOGIN_DENTISTA")
                .IsRequired();

            // Unidade

            modelBuilder.Entity<Unidade>()
                .HasOne(u => u.Endereco) 
                .WithMany() 
                .HasForeignKey(u => u.IdEndereco)
                .HasConstraintName("FK_ENDERECO_UNIDADE");

            modelBuilder.Entity<Unidade>()
            .HasMany(u => u.Consultas)
            .WithOne(c => c.Unidade)
            .HasForeignKey(c => c.IdUnidade);

            // Consulta

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Dentista)
                .WithMany()
                .HasForeignKey(c => c.IdDentista)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Unidade)
                .WithMany()
                .HasForeignKey(c => c.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict);

            // Chaves primarias

            modelBuilder.Entity<Genero>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Login>()
                .HasKey(l => l.ID);

            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
