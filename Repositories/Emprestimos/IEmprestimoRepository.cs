using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Repositories.Emprestimos
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
