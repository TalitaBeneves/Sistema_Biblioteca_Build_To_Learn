using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Repositories.Interface;
using Sistema_Biblioteca.Services.Interface;

namespace Sistema_Biblioteca.Services
{
    public class BibliotecaLivroService : IBibliotecaLivroService
    {
        private readonly IBibliotecaLivroRepositorie bibliotecaRepositorie;

        public BibliotecaLivroService(IBibliotecaLivroRepositorie bibliotecaRepositorie)
        {
            this.bibliotecaRepositorie = bibliotecaRepositorie;
        }

        public async Task<Livro> CreateLivroAsync(Livro livro)
        {
            await bibliotecaRepositorie.Create(livro);
            Console.WriteLine($"Livro '{livro.Nome}' cadastrado com sucesso!");
            return livro;
        }

        public Task<bool> DeleteLivroAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> GetAllLivrosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Livro> GetLivroByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> UpdateLivroAsync(int id, Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}
