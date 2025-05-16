using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Repositories;
using c_sharp_odontoprev.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("OracleDbContext");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


builder.Services.AddScoped<IRepository<Estado>, Repository<Estado>>();
builder.Services.AddScoped<IService<Estado>, Service<Estado>>();

builder.Services.AddScoped<IRepository<Cidade>, Repository<Cidade>>();
builder.Services.AddScoped<IService<Cidade>, Service<Cidade>>();

builder.Services.AddScoped<IRepository<Bairro>, Repository<Bairro>>();
builder.Services.AddScoped<IService<Bairro>, Service<Bairro>>();

builder.Services.AddScoped<IRepository<Endereco>, Repository<Endereco>>();
builder.Services.AddScoped<IService<Endereco>, Service<Endereco>>();

builder.Services.AddScoped<IRepository<Login>, Repository<Login>>();
builder.Services.AddScoped<IService<Login>, Service<Login>>();

builder.Services.AddScoped<IRepository<Unidade>, Repository<Unidade>>();
builder.Services.AddScoped<IService<Unidade>, Service<Unidade>>();

builder.Services.AddScoped<IRepository<Consulta>, Repository<Consulta>>();
builder.Services.AddScoped<IService<Consulta>, Service<Consulta>>();

builder.Services.AddScoped<IRepository<Paciente>, Repository<Paciente>>();
builder.Services.AddScoped<IService<Paciente>, Service<Paciente>>();

builder.Services.AddScoped<IRepository<Dentista>, Repository<Dentista>>();
builder.Services.AddScoped<IService<Dentista>, Service<Dentista>>();

builder.Services.AddSingleton<MLService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization(); 

app.MapControllers();

app.Run();

