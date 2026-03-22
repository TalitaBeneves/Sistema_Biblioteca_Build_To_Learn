using Microsoft.AspNetCore.Mvc;
using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Services;
using Sistema_Biblioteca.Services.Interface;

namespace Sistema_Biblioteca.Controllers
{
    [ApiController]
    [Route("api/biblioteca")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaLivroService bibliotecaLivroService;

        public BibliotecaController(IBibliotecaLivroService bibliotecaLivroService)
        {
            this.bibliotecaLivroService = bibliotecaLivroService;
        }

        [HttpPost("cadastrar-livro")]
        public async Task<IActionResult> CadastrarLivro([FromBody] Livro livro)
        {
            await bibliotecaLivroService.CreateLivroAsync(livro);
            return Ok($"Livro '{livro.Nome}' cadastrado com sucesso!");
        }

    }
}
