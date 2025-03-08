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
}
}
