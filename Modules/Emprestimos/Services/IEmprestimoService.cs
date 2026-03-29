using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Response;

namespace Sistema_Biblioteca.Modules.Emprestimos.Services
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<EmprestimoResponseDto>> GetAllEmprestimosAsync();
        Task<EmprestimoResponseDto?> GetEmprestimoByIdAsync(int id);
        Task<EmprestimoResponseDto> CreateEmprestimoAsync(EmprestimoRequestDto dto);
        Task<EmprestimoResponseDto> UpdateEmprestimoAsync(int id, EmprestimoRequestDto dto);
        Task DeleteEmprestimoAsync(int id);
        Task<EmprestimoResponseDto> DevolverEmprestimoAsync(int id);
        Task<EmprestimoResponseDto> RenovarAsync(int id);
    }
}
