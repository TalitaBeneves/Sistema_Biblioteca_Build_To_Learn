using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Response;
using Sistema_Biblioteca.Modules.Emprestimos.Mappers;
using Sistema_Biblioteca.Modules.Emprestimos.Repositories;

namespace Sistema_Biblioteca.Modules.Emprestimos.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository emprestimoRepository;
        private readonly IEmprestimoMapper emprestimoMapper;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IEmprestimoMapper emprestimoMapper)
        {
            this.emprestimoRepository = emprestimoRepository;
            this.emprestimoMapper = emprestimoMapper;
        }

        public async Task<IEnumerable<EmprestimoResponseDto>> GetAllEmprestimosAsync()
        {
            var emprestimo = await emprestimoRepository.GetAll();
            return emprestimo.Select(emprestimoMapper.ToResponseDto);
        }

        public async Task<EmprestimoResponseDto?> GetEmprestimoByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException($"O id: {id} do empréstimo deve ser maior que zero.");

            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado."); ;
            return emprestimoMapper.ToResponseDto(emprestimo);
        }

        public async Task<EmprestimoResponseDto> CreateEmprestimoAsync(EmprestimoRequestDto dto)
        {
            //quando tivermos o usuário, vamos verificar quantos emprestimos ele ja fez, e se ele tiver mais de 5 emprestimos ativos, não vamos permitir que ele faça um novo emprestimo, e vamos lançar uma exceção dizendo que ele já tem 3 emprestimos ativos, e que ele precisa devolver um livro para poder fazer um novo emprestimo.
            var request = emprestimoMapper.ToEntity(dto);
            var emprestimo = await emprestimoRepository.Add(request);

            return emprestimoMapper.ToResponseDto(emprestimo);
        }

        public async Task<EmprestimoResponseDto> UpdateEmprestimoAsync(int id, EmprestimoRequestDto dto)
        {
            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado");
            emprestimoMapper.UpdateEntity(emprestimo, dto);

            await emprestimoRepository.Update(emprestimo);
            return emprestimoMapper.ToResponseDto(emprestimo);
        }

        public async Task DeleteEmprestimoAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("O id do empréstimo deve ser maior que zero.");

            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado."); ;
            await emprestimoRepository.Delete(emprestimo);
        }

        public async Task<EmprestimoResponseDto> DevolverEmprestimoAsync(int id)
        {
            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado.");
            emprestimo.DataDevolucao = DateTime.UtcNow;

            await emprestimoRepository.Update(emprestimo);
            return emprestimoMapper.ToResponseDto(emprestimo);
        }

        public async Task<EmprestimoResponseDto> RenovarAsync(int id)
        {
            var emprestimo = await emprestimoRepository.GetById(id) ?? throw new Exception("Emprétimo não encontrado.");
            emprestimo.DataLimite = DateTime.UtcNow.AddDays(20);
            emprestimo.IsRenovado = true;

            await emprestimoRepository.Update(emprestimo);
            return emprestimoMapper.ToResponseDto(emprestimo);
        }
    }
}
