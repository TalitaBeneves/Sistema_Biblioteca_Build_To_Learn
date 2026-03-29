using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Response;
using Sistema_Biblioteca.Modules.Emprestimos.Entities;

namespace Sistema_Biblioteca.Modules.Emprestimos.Mappers
{
    public class EmprestimoMapper : IEmprestimoMapper
    {
        public Emprestimo ToEntity(EmprestimoRequestDto dto)
        {
            return new Emprestimo
            {
                Id = dto.Id,
                LivroId = dto.LivroId,
                DataEmprestimo = dto.DataEmprestimo,
                DataDevolucao = dto.DataDevolucao
            };
        }

        public EmprestimoResponseDto ToResponseDto(Emprestimo livro)
        {
            return new EmprestimoResponseDto
            {
                Id = livro.Id,
                LivroId = livro.LivroId,
                DataEmprestimo = livro.DataEmprestimo,
                DataDevolucao = livro.DataDevolucao
            };
        }

        public void UpdateEntity(Emprestimo emprestimo, EmprestimoRequestDto dto)
        {
            emprestimo.LivroId = dto.LivroId;
            emprestimo.DataEmprestimo = dto.DataEmprestimo;
            emprestimo.DataDevolucao = dto.DataDevolucao;
            emprestimo.Id = dto.Id;
        }
    }
}
