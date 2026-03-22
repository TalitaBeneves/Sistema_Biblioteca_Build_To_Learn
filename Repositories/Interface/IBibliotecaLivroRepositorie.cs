using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Repositories.Interface
{
    public interface IBibliotecaLivroRepositorie
    {
        Task<Livro> Create(Livro livro);
        Task<Livro> Update(Livro livro);
        Task<bool> Delete(int id);
        Task<Livro> GetById(int id);
        Task<IEnumerable<Livro>> GetAll();
    }
}
