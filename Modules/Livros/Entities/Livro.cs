using static Sistema_Biblioteca.Shared.Enums;

namespace Sistema_Biblioteca.Modules.Livros.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string? SobreAutor { get; set; }
        public CategoriaLivro Categoria { get; set; } 
        public string? Descricao { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int Edicao { get; set; }
        public string Idioma { get; set; } = string.Empty;
        public int NumeroDePaginas { get; set; }
        public List<ItemLivro> Itens { get; set; } = new List<ItemLivro>();
        public DateTime DataCadastro { get; set; }
    }
}
