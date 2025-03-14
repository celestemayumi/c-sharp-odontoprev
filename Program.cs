using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Repositories;
using c_sharp_odontoprev.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("OracleDbContext");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddControllers(); // <- Adiciona os controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Estado>, Repository<Estado>>();
builder.Services.AddScoped<IService<Estado>, Service<Estado>>();

builder.Services.AddScoped<IRepository<Cidade>, Repository<Cidade>>();
builder.Services.AddScoped<IService<Cidade>, Service<Cidade>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); 

app.MapControllers(); 

app.Run();

