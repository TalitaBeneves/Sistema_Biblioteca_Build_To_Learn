namespace Sistema_Biblioteca.DTOs.Livro.Response
{
    public class LivroResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = String.Empty;
        public string UrlCapa { get; set; } = String.Empty;
        public string Autor { get; set; } = String.Empty;
        public string? SobreAutor { get; set; }
        public string Categoria { get; set; } = String.Empty;
        public string? Descricao { get; set; }
        public string ISBN { get; set; } = String.Empty;
        public int Ano { get; set; }
        public int Edicao { get; set; }
        public string Idioma { get; set; } = String.Empty;
        public int NumeroDePaginas { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
