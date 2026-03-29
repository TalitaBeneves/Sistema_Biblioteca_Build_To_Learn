using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Sistema_Biblioteca.Data;
using FluentValidation;
using Sistema_Biblioteca.Modules.Livros.Repositories;
using Sistema_Biblioteca.Modules.Livros.Services;
using Sistema_Biblioteca.Modules.Livros.Mappers;
using Sistema_Biblioteca.Modules.Livros.Validators;
using Sistema_Biblioteca.Modules.Emprestimos.Services;
using Sistema_Biblioteca.Modules.Emprestimos.Repositories;
using Sistema_Biblioteca.Shared.Exceptions;
using Sistema_Biblioteca.Modules.Emprestimos.Mappers;

var builder = WebApplication.CreateBuilder(args);
var conectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)).UseSnakeCaseNamingConvention());
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<LivroDtoValidator>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<ILivroMapper, LivroMapper>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IEmprestimoMapper, EmprestimoMapper>();

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(op =>
{
    op.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Erro de validação no JSON",
            Detail = "Um ou mais campos enviados estão com formato incorreto.",
            Instance = context.HttpContext.Request.Path
        };

        problemDetails.Extensions.Add("erros", context.ModelState.Where(kv => kv.Value.Errors.Count > 0)
                                 .ToDictionary(kv => kv.Key, kv => kv.Value.Errors.Select(e => e.ErrorMessage).ToArray()));

        return new BadRequestObjectResult(problemDetails);
    };
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
