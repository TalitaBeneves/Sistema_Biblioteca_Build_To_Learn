namespace Sistema_Biblioteca.Modules.Livros.DTOs.Response
{
    public class LivroResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string? SobreAutor { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int Edicao { get; set; }
        public string Idioma { get; set; } = string.Empty;
        public int NumeroDePaginas { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
