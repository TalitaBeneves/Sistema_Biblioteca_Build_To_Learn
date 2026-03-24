using Microsoft.EntityFrameworkCore;
using Sistema_Biblioteca.Data;
using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Repositories.Emprestimos
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext bibliotecaContext;

        public EmprestimoRepository(BibliotecaContext bibliotecaContext)
        {
            this.bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<Emprestimo>> GetAll()
        {
            return await bibliotecaContext.Emprestimos.ToListAsync();
        }

        public async Task<Emprestimo?> GetById(int id)
        {
            return await bibliotecaContext.Emprestimos.FindAsync(id);
        }

        public async Task<Emprestimo> Add(Emprestimo emprestimo)
        {
            await bibliotecaContext.Emprestimos.AddAsync(emprestimo);
            await bibliotecaContext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task Update(Emprestimo emprestimo)
        {
            bibliotecaContext.Emprestimos.Update(emprestimo);
            await bibliotecaContext.SaveChangesAsync();
        }

        public async Task Delete(Emprestimo emprestimo)
        {
            bibliotecaContext.Emprestimos.Remove(emprestimo);
            await bibliotecaContext.SaveChangesAsync();
        }
    }
}
