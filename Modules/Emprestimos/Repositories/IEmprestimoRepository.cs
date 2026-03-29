using Sistema_Biblioteca.Modules.Emprestimos.Entities;

namespace Sistema_Biblioteca.Modules.Emprestimos.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> GetAll();
        Task<Emprestimo?> GetById(int id);
        Task<Emprestimo> Add(Emprestimo emprestimo);
        Task Update(Emprestimo emprestimo);
        Task Delete(Emprestimo emprestimo);
    }
}
