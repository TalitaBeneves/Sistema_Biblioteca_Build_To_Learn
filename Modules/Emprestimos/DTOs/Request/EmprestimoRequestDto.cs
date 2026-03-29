using Sistema_Biblioteca.Modules.Livros.Entities;

namespace Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request
{
    public class EmprestimoRequestDto
    {
        public int Id { get; set; }
        //public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
