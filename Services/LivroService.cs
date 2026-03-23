using Sistema_Biblioteca.Controllers.Dtos;
using Sistema_Biblioteca.Entities;
using Sistema_Biblioteca.Repositories.Interface;
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

        public async Task<ListarLivrosDto> CreateLivroAsync(CadastrarLivroDto livro)
        {
            var request = new Livro { Nome = livro.Nome, DataCadastro = DateTime.UtcNow };
            await livroRepository.Create(request);

            return new ListarLivrosDto { Id = request.Id, Nome = request.Nome };
        }

        public async Task DeleteLivroAsync(int id)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            await livroRepository.Delete(livro);
        }

        public async Task<IEnumerable<ListarLivrosDto>> GetAllLivrosAsync()
        {
            var livros = await livroRepository.GetAll();

            return livros.Select(livro => new ListarLivrosDto { Id = livro.Id, Nome = livro.Nome, DataCadastro = livro.DataCadastro }).ToList();
        }

        public async Task<ListarLivrosDto> GetLivroByIdAsync(int id)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            return new ListarLivrosDto { Id = livro.Id, Nome = livro.Nome, DataCadastro = livro.DataCadastro };
        }

        public async Task<ListarLivrosDto> UpdateLivroAsync(int id, AtualizarLivroDto dto)
        {
            var livro = await livroRepository.GetById(id) ?? throw new Exception("Livro não encontrado");
            livro.Nome = dto.Nome;
            
            await livroRepository.Update(livro);
            return new ListarLivrosDto { Id = livro.Id, Nome = livro.Nome };
        }
    }
}
