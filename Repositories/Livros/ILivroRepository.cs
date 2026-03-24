using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Repositories.Livros
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetAll();
        Task<Livro?> GetById(int id);
        Task<Livro> Add(Livro livro);
        Task Update(Livro livro);
        Task Delete(Livro livro);
    }
}
