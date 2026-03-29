//using Sistema_Biblioteca.Modules.Usuairo.Entities;
using Sistema_Biblioteca.Modules.Livros.Entities;

namespace Sistema_Biblioteca.Modules.Emprestimos.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }
        //public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimite { get; set; }
        public bool IsRenovado { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Livro Livro { get; set; } = new Livro();
        //public Usuario Usuario { get; set; } = new Usuario();
    }
}
