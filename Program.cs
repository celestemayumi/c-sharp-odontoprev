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

