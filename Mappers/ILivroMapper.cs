using Sistema_Biblioteca.DTOs.Livro.Request;
using Sistema_Biblioteca.DTOs.Livro.Response;
using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Mappers
{
    public interface ILivroMapper
    {
        Livro ToEntity(LivroRequestDto cadastrarLivroDto);
        LivroResponseDto ToResponseDto(Livro livro);
    }
}
