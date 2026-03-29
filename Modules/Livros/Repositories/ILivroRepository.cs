using Sistema_Biblioteca.Modules.Livros.Entities;

namespace Sistema_Biblioteca.Modules.Livros.Repositories
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
