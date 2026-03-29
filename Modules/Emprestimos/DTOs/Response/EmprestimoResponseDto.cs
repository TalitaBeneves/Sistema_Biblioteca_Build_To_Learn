namespace Sistema_Biblioteca.Modules.Emprestimos.DTOs.Response
{
    public class EmprestimoResponseDto
    {
        public int Id { get; set; }
        //public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimite { get; set; }
        public bool IsRenovado { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
