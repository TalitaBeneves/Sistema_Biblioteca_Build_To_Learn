using static Sistema_Biblioteca.Shared.Enums;

namespace Sistema_Biblioteca.Modules.Livros.Entities
{
    public class ItemLivro
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; } = new Livro();
        public string CodigoBarras { get; set; } = null!;
        public StatusLivro Status { get; set; }
        public DateTime? DataCancelamentoReserva { get; set; }
    }
}
