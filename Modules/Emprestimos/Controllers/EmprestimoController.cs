using Microsoft.AspNetCore.Mvc;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;
using Sistema_Biblioteca.Modules.Emprestimos.Services;

namespace Sistema_Biblioteca.Modules.Emprestimos.Controllers
{
    [ApiController]
    [Route("api/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            this.emprestimoService = emprestimoService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarEmprestimos()
        {
            var emprestimos = await emprestimoService.GetAllEmprestimosAsync();
            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarEmprestimosPorId([FromRoute] int id)
        {
            var emprestimo = await emprestimoService.GetEmprestimoByIdAsync(id);
            return Ok(emprestimo);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarEmprestimo([FromBody] EmprestimoRequestDto emprestimo)
        {
            await emprestimoService.CreateEmprestimoAsync(emprestimo);
            return Ok(new { message = $"Empréstimo cadastrado com sucesso!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaEmprestimo([FromRoute] int id, [FromBody] EmprestimoRequestDto emprestimo)
        {
            await emprestimoService.UpdateEmprestimoAsync(id, emprestimo);
            return Ok(new { message = $"Empréstimo  atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEmprestimo([FromRoute] int id)
        {
            await emprestimoService.DeleteEmprestimoAsync(id);
            return Ok(new { message = $"Empréstimo deletado com sucesso!" });
        }

        [HttpPut("DevolverEmprestimo{id}")]
        public async Task<IActionResult> DevolverEmprestimo([FromRoute] int id)
        {
            var result = await emprestimoService.DevolverEmprestimoAsync(id);
            return Ok(new { message = $"Livro devolvido com sucesso!" });
        }

        [HttpPut("RenovarEmprestimo{id}")]
        public async Task<IActionResult> RenovarEmprestimo([FromRoute] int id)
        {
            var result = await emprestimoService.RenovarAsync(id);
            return Ok(new { message = $"Empréstimo renovado com sucesso!" });
        }
    }
}
