namespace Sistema_Biblioteca.DTOs.Emprestimo
{
    public class EmprestimoResponseDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
