using FluentValidation;
using Sistema_Biblioteca.DTOs.Livro.Request;
using Sistema_Biblioteca.DTOs.Livro.Response;
using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Mappers;
using Sistema_Biblioteca.Repositories.Livros;
using Sistema_Biblioteca.Services.Interface;
using Sistema_Biblioteca.Validators;

namespace Sistema_Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository livroRepository;
        private readonly IValidator<LivroRequestDto> validator;
        private readonly ILivroMapper livroMapper;

        public LivroService(ILivroRepository livroRepository, IValidator<LivroRequestDto> validator, ILivroMapper livroMapper)
        {
            this.livroRepository = livroRepository;
            this.validator = validator;
            this.livroMapper = livroMapper;
        }

        public async Task<LivroResponseDto> CreateLivroAsync(LivroRequestDto livro)
        {
            var validationResult = await validator.ValidateAsync(livro);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var pasta = Path.Combine("wwwroot/images/livros");
            if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

            var nomeArquivo = $"{Guid.NewGuid()}{Path.GetExtension(livro.Capa!.FileName)}";
            var caminho = Path.Combine(pasta, nomeArquivo);

            using (var stream = new FileStream(caminho, FileMode.Create))
                await livro.Capa!.CopyToAsync(stream);

            var request = livroMapper.ToEntity(livro);
            request.UrlCapa = $"/images/livros/{nomeArquivo}";

            await livroRepository.Add(request);
            return livroMapper.ToResponseDto(request);
        }

        public async Task DeleteLivroAsync(int id)
        {
            if (id <= 0) throw new Exception($"O id:{id} do livro deve ser maior que zero.");

            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            await livroRepository.Delete(livro);
        }

        public async Task<IEnumerable<LivroResponseDto>> GetAllLivrosAsync()
        {
            var livros = await livroRepository.GetAll();

            return livros.Select(livro => livroMapper.ToResponseDto(livro)).ToList();
        }

        public async Task<LivroResponseDto> GetLivroByIdAsync(int id)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            return livroMapper.ToResponseDto(livro);
        }

        public async Task<LivroResponseDto> UpdateLivroAsync(int id, LivroRequestDto dto)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");

            var request = livroMapper.UpdateEntity(livro, dto);
            if (dto.Capa != null)
            {
                var pasta = Path.Combine("wwwroot/images/livros");
                if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                var nomeArquivo = $"{Guid.NewGuid()}{Path.GetExtension(dto.Capa.FileName)}";
                var caminho = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminho, FileMode.Create))
                    await dto.Capa.CopyToAsync(stream);

                request.UrlCapa = $"/images/livros/{nomeArquivo}";

                var urlAntiga = livro.UrlCapa;
                if (!string.IsNullOrEmpty(urlAntiga))
                {
                    var caminhoAntigo = Path.Combine("wwwroot/images/livros", urlAntiga.TrimStart('/'));
                    if (File.Exists(caminhoAntigo)) File.Delete(caminhoAntigo);
                }
            }

            await livroRepository.Update(livro);
            return livroMapper.ToResponseDto(livro);
        }

        public Task Reservar(int id)
        {
            throw new NotImplementedException();
        }

        public Task CancelarReserva(int id)
        {
            throw new NotImplementedException();
        }
    }
}
