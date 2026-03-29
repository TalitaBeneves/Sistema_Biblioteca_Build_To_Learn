using Microsoft.AspNetCore.Mvc;
using Sistema_Biblioteca.Modules.Livros.DTOs.Request;
using Sistema_Biblioteca.Modules.Livros.Services;

namespace Sistema_Biblioteca.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService bibliotecaLivroService;

        public LivroController(ILivroService bibliotecaLivroService)
        {
            this.bibliotecaLivroService = bibliotecaLivroService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarLivros()
        {
            var livros = await bibliotecaLivroService.GetAllLivrosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarLivroPorId([FromRoute] int id)
        {
            var livro = await bibliotecaLivroService.GetLivroByIdAsync(id);
            return Ok(livro);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarLivro([FromBody] LivroRequestDto livro)
        {
            await bibliotecaLivroService.CreateLivroAsync(livro);
            return Ok(new { message = $"Livro '{livro.Titulo}' cadastrado com sucesso!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaLivro([FromRoute] int id, [FromBody] LivroRequestDto livro)
        {
            await bibliotecaLivroService.UpdateLivroAsync(id, livro);
            return Ok(new { message = $"Livro '{livro.Titulo}' atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro([FromRoute] int id)
        {
            await bibliotecaLivroService.DeleteLivroAsync(id);
            return Ok(new { message = $"Livro deletado com sucesso!" });
        }
    }
}
