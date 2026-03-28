using Sistema_Biblioteca.DTOs.Livro.Request;
using Sistema_Biblioteca.DTOs.Livro.Response;
using Sistema_Biblioteca.Entities;

namespace Sistema_Biblioteca.Mappers
{
    public class LivroMapper : ILivroMapper
    {
        public Livro ToEntity(LivroRequestDto dto)
        {
            return new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                SobreAutor = dto.SobreAutor,
                Categoria = dto.Categoria,
                Descricao = dto.Descricao,
                ISBN = dto.ISBN,
                Ano = dto.Ano,
                Edicao = dto.Edicao,
                Idioma = dto.Idioma,
                NumeroDePaginas = dto.NumeroDePaginas,
                DataCadastro = DateTime.Now
            };
        }

        public LivroResponseDto ToResponseDto(Livro livro)
        {
            return new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                UrlCapa = livro.UrlCapa,
                Autor = livro.Autor,
                SobreAutor = livro.SobreAutor,
                Categoria = livro.Categoria,
                Descricao = livro.Descricao,
                ISBN = livro.ISBN,
                Ano = livro.Ano,
                Edicao = livro.Edicao,
                Idioma = livro.Idioma,
                NumeroDePaginas = livro.NumeroDePaginas,
                DataCadastro = livro.DataCadastro
            };
        }

        public void UpdateEntity(Livro livro, LivroRequestDto dto)
        {
            livro.Titulo = dto.Titulo;
            livro.Autor = dto.Autor;
            livro.Categoria = dto.Categoria;
            livro.ISBN = dto.ISBN;
            livro.Ano = dto.Ano;
            livro.Edicao = dto.Edicao;
            livro.Idioma = dto.Idioma;
            livro.NumeroDePaginas = dto.NumeroDePaginas;
            livro.Descricao = dto.Descricao;
            livro.SobreAutor = dto.SobreAutor;
        }
    }
}
