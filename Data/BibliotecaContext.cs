using Microsoft.EntityFrameworkCore;
using Sistema_Biblioteca.Modules.Emprestimos.Entities;
using Sistema_Biblioteca.Modules.Livros.Entities;
using Sistema_Biblioteca.Modules.Usuairo.Entities;

namespace Sistema_Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
