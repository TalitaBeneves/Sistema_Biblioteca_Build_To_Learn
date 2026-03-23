using Sistema_Biblioteca.Controllers.Dtos;

namespace Sistema_Biblioteca.Services.Interface
{
    public interface ILivroService
    {
        Task<IEnumerable<ListarLivrosDto>> GetAllLivrosAsync();
        Task<ListarLivrosDto> GetLivroByIdAsync(int id);
        Task<ListarLivrosDto> CreateLivroAsync(CadastrarLivroDto livro);
        Task<ListarLivrosDto> UpdateLivroAsync(int id, AtualizarLivroDto livro);
        Task DeleteLivroAsync(int id);
    }
}
