using Sistema_Biblioteca.DTOs.Emprestimo;
using Sistema_Biblioteca.Modules.Emprestimos.Entities;
using Sistema_Biblioteca.Modules.Emprestimos.Repositories;

namespace Sistema_Biblioteca.Modules.Emprestimos.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            this.emprestimoRepository = emprestimoRepository;
        }

        public async Task<IEnumerable<EmprestimoResponseDto>> GetAllEmprestimosAsync()
        {
            var emprestimo = await emprestimoRepository.GetAll();
            return emprestimo.Select(e => new EmprestimoResponseDto { Id = e.Id, UsuarioId = e.UsuarioId, LivroId = e.LivroId, DataEmprestimo = e.DataEmprestimo, DataDevolucao = e.DataDevolucao });
        }

        public async Task<EmprestimoResponseDto?> GetEmprestimoByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id do empréstimo deve ser maior que zero.");

            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado."); ;
            return new EmprestimoResponseDto { Id = emprestimo.Id, UsuarioId = emprestimo.UsuarioId, LivroId = emprestimo.LivroId, DataEmprestimo = emprestimo.DataEmprestimo, DataDevolucao = emprestimo.DataDevolucao };
        }

        public async Task<EmprestimoResponseDto> CreateEmprestimoAsync(CadastrarEmprestimoDto dto)
        {
            //quando tivermos o usuário, vamos verificar quantos emprestimos ele ja fez, e se ele tiver mais de 5 emprestimos ativos, não vamos permitir que ele faça um novo emprestimo, e vamos lançar uma exceção dizendo que ele já tem 3 emprestimos ativos, e que ele precisa devolver um livro para poder fazer um novo emprestimo.
            var request = new Emprestimo { UsuarioId = dto.UsuarioId, LivroId = dto.LivroId, DataEmprestimo = DateTime.UtcNow };
            var emprestimo = await emprestimoRepository.Add(request);

            return new EmprestimoResponseDto
            {
                Id = emprestimo.Id,
                UsuarioId = emprestimo.UsuarioId,
                LivroId = emprestimo.LivroId,
                DataEmprestimo = emprestimo.DataEmprestimo,
            };
        }

        public async Task<EmprestimoResponseDto> UpdateEmprestimoAsync(int id, AtualizarEmprestimoDto dto)
        {
            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado");
            emprestimo.UsuarioId = dto.UsuarioId;
            emprestimo.LivroId = dto.LivroId;

            await emprestimoRepository.Update(emprestimo);
            return new EmprestimoResponseDto { UsuarioId = emprestimo.UsuarioId, LivroId = emprestimo.LivroId, DataEmprestimo = emprestimo.DataEmprestimo };
        }

        public async Task DeleteEmprestimoAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id do empréstimo deve ser maior que zero.");

            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado."); ;
            await emprestimoRepository.Delete(emprestimo);
        }

        public Task DevolverLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task Renovar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
