using Sistema_Biblioteca.Modules.Livros.Entities;
using Sistema_Biblioteca.Modules.Livros.DTOs.Request;
using Sistema_Biblioteca.Modules.Livros.DTOs.Response;

namespace Sistema_Biblioteca.Modules.Livros.Mappers
{
    public interface ILivroMapper
    {
        Livro ToEntity(LivroRequestDto dto);
        void UpdateEntity(Livro livro, LivroRequestDto dto);
        LivroResponseDto ToResponseDto(Livro livro);
    }
}
