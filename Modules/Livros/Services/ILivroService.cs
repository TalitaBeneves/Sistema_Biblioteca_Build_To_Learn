using Sistema_Biblioteca.Modules.Livros.DTOs.Request;
using Sistema_Biblioteca.Modules.Livros.DTOs.Response;

namespace Sistema_Biblioteca.Modules.Livros.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResponseDto>> GetAllLivrosAsync();
        Task<LivroResponseDto> GetLivroByIdAsync(int id);
        Task<LivroResponseDto> CreateLivroAsync(LivroRequestDto livro);
        Task<LivroResponseDto> UpdateLivroAsync(int id, LivroRequestDto livro);
        Task DeleteLivroAsync(int id);

        Task<LivroResponseDto> CriarReservaAsync(int id);
        Task<LivroResponseDto> CancelarReservaAsync(int id);
    }
}
