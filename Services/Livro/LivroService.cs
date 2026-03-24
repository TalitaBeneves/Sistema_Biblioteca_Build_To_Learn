using Sistema_Biblioteca.Controllers.Dtos;
using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Repositories.Livros;
using Sistema_Biblioteca.Services.Interface;

namespace Sistema_Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            this.livroRepository = livroRepository;
        }

        public async Task<LivroReponseDto> CreateLivroAsync(CadastrarLivroDto livro)
        {
            var request = new Livro { Nome = livro.Nome, DataCadastro = DateTime.UtcNow };
            await livroRepository.Add(request);

            return new LivroReponseDto { Id = request.Id, Nome = request.Nome };
        }

        public async Task DeleteLivroAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id do livro deve ser maior que zero.");

            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            await livroRepository.Delete(livro);
        }

        public async Task<IEnumerable<LivroReponseDto>> GetAllLivrosAsync()
        {
            var livros = await livroRepository.GetAll();

            return livros.Select(livro => new LivroReponseDto { Id = livro.Id, Nome = livro.Nome, DataCadastro = livro.DataCadastro }).ToList();
        }

        public async Task<LivroReponseDto> GetLivroByIdAsync(int id)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            return new LivroReponseDto { Id = livro.Id, Nome = livro.Nome, DataCadastro = livro.DataCadastro };
        }

        public async Task<LivroReponseDto> UpdateLivroAsync(int id, AtualizarLivroDto dto)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            livro.Nome = dto.Nome;

            await livroRepository.Update(livro);
            return new LivroReponseDto { Id = livro.Id, Nome = livro.Nome };
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
