namespace Sistema_Biblioteca.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
    }
}
