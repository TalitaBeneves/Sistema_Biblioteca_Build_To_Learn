using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Sistema_Biblioteca.Data;
using Sistema_Biblioteca.Handlers;
using Sistema_Biblioteca.Repositories.Emprestimos;
using Sistema_Biblioteca.Repositories.Livros;
using Sistema_Biblioteca.Services;
using Sistema_Biblioteca.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
var conectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)).UseSnakeCaseNamingConvention());
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(op =>
{
    op.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Erro de validação no JSON",
            Detail = "Um ou mais campos enviados estãõ com formato incorreto.",
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
