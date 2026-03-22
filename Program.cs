using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Sistema_Biblioteca.Data;
using Sistema_Biblioteca.Repositories;
using Sistema_Biblioteca.Repositories.Interface;
using Sistema_Biblioteca.Services;
using Sistema_Biblioteca.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)).UseSnakeCaseNamingConvention());
builder.Services.AddScoped<IBibliotecaLivroRepositorie, BibliotecaLivroRepositorie>();
builder.Services.AddScoped<IBibliotecaLivroService, BibliotecaLivroService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
