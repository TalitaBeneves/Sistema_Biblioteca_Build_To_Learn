namespace Sistema_Biblioteca.Controllers.Dtos
{
    public class LivroReponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public DateTime DataCadastro { get; set; }
    }
}
