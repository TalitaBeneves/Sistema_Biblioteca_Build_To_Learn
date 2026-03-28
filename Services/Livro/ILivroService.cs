using Sistema_Biblioteca.DTOs.Livro.Request;
using Sistema_Biblioteca.DTOs.Livro.Response;

namespace Sistema_Biblioteca.Services.Interface
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResponseDto>> GetAllLivrosAsync();
        Task<LivroResponseDto> GetLivroByIdAsync(int id);
        Task<LivroResponseDto> CreateLivroAsync(LivroRequestDto livro);
        Task<LivroResponseDto> UpdateLivroAsync(int id, LivroRequestDto livro);
        Task DeleteLivroAsync(int id);
    }
}
