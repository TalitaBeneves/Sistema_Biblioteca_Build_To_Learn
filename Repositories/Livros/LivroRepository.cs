using Microsoft.EntityFrameworkCore;
using Sistema_Biblioteca.Data;
using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Repositories.Livros
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext bibliotecaContext;

        public LivroRepository(BibliotecaContext bibliotecaContext)
        {
            this.bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await bibliotecaContext.Livros.ToListAsync();
        }

        public async Task<Livro?> GetById(int id)
        {
            return await bibliotecaContext.Livros.FindAsync(id);
        }

        public async Task<Livro> Add(Livro livro)
        {
            await bibliotecaContext.Livros.AddAsync(livro);
            await bibliotecaContext.SaveChangesAsync();

            return livro;
        }

        public async Task Update(Livro livro)
        {
            bibliotecaContext.Livros.Update(livro);
            await bibliotecaContext.SaveChangesAsync();
        }

        public async Task Delete(Livro livro)
        {
            bibliotecaContext.Livros.Remove(livro);
            await bibliotecaContext.SaveChangesAsync();
        }
    }
}
