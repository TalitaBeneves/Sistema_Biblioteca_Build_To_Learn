using Sistema_Biblioteca.Controllers.Dtos;

namespace Sistema_Biblioteca.Services.Interface
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroReponseDto>> GetAllLivrosAsync();
        Task<LivroReponseDto> GetLivroByIdAsync(int id);
        Task<LivroReponseDto> CreateLivroAsync(CadastrarLivroDto livro);
        Task<LivroReponseDto> UpdateLivroAsync(int id, AtualizarLivroDto livro);
        Task DeleteLivroAsync(int id);
    }
}
