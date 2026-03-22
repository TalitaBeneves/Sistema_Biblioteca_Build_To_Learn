using Sistema_Biblioteca.Data;
using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Repositories.Interface;

namespace Sistema_Biblioteca.Repositories
{
    public class BibliotecaLivroRepositorie : IBibliotecaLivroRepositorie
    {
        private readonly BibliotecaContext bibliotecaContext;

        public BibliotecaLivroRepositorie(BibliotecaContext bibliotecaContext)
        {
            this.bibliotecaContext = bibliotecaContext;
        }

        public async Task<Livro> Create(Livro livro)
        {
            livro.DataCadastro = DateTime.UtcNow;
            await bibliotecaContext.Livros.AddAsync(livro);
            await bibliotecaContext.SaveChangesAsync();

            return livro;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Livro> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> Update(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}
