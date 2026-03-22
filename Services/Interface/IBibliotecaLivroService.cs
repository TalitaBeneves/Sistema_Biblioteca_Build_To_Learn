using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Services.Interface
{
    public interface IBibliotecaLivroService
    {
            Task<IEnumerable<Livro>> GetAllLivrosAsync();
            Task<Livro> GetLivroByIdAsync(int id);
            Task<Livro> CreateLivroAsync(Livro livro);
            Task<Livro> UpdateLivroAsync(int id, Livro livro);
            Task<bool> DeleteLivroAsync(int id);
    }
}
