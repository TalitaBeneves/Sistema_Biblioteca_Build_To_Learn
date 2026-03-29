using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Response;
using Sistema_Biblioteca.Modules.Emprestimos.Entities;

namespace Sistema_Biblioteca.Modules.Emprestimos.Mappers
{
    public interface IEmprestimoMapper
    {
        Emprestimo ToEntity(EmprestimoRequestDto dto);
        void UpdateEntity(Emprestimo emprestimo, EmprestimoRequestDto dto);
        EmprestimoResponseDto ToResponseDto(Emprestimo livro);
    }
}
