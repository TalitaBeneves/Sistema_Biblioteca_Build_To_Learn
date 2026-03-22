namespace Sistema_Biblioteca.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public DateTime DataCadastro { get; set; }
    }
}
