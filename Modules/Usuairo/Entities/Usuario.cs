using Sistema_Biblioteca.Modules.Emprestimos.Entities;

namespace Sistema_Biblioteca.Modules.Usuairo.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
    }
}
