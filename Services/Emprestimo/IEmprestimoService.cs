using Sistema_Biblioteca.DTOs.Emprestimo;

namespace Sistema_Biblioteca.Services.Interface
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<EmprestimoResponseDto>> GetAllEmprestimosAsync();
        Task<EmprestimoResponseDto?> GetEmprestimoByIdAsync(int id);
        Task<EmprestimoResponseDto> CreateEmprestimoAsync(CadastrarEmprestimoDto dto);
        Task<EmprestimoResponseDto> UpdateEmprestimoAsync(int id, AtualizarEmprestimoDto dto);
        Task DeleteEmprestimoAsync(int id);
        Task DevolverLivro(int id);
    }
}
