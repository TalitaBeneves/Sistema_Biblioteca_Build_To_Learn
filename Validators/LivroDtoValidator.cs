using FluentValidation;
using Sistema_Biblioteca.DTOs.Livro.Request;

namespace Sistema_Biblioteca.Validators
{
    public class LivroDtoValidator : AbstractValidator<LivroRequestDto>
    {
        public LivroDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório.")
                .MinimumLength(3).WithMessage("Título deve ter no mínimo 3 caracteres.")
                .MaximumLength(255).WithMessage("Título deve ter no máximo 255 caracteres.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("Autor é obrigatório.")
                .MinimumLength(3).WithMessage("Autor deve ter no mínimo 3 caracteres.")
                .MaximumLength(255).WithMessage("Autor deve ter no máximo 255 caracteres.");

            RuleFor(x => x.Categoria)
                .NotEmpty().WithMessage("Categoria é obrigatória.")
                .MaximumLength(100).WithMessage("Categoria deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Idioma)
                .NotEmpty().WithMessage("Idioma é obrigatório.")
                .MaximumLength(50).WithMessage("Idioma deve ter no máximo 50 caracteres.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN é obrigatório.")
                .Length(10, 13).WithMessage("ISBN deve ter entre 10 e 13 caracteres.")
                .Matches(@"^\d+$").WithMessage("ISBN deve conter apenas números.");

            RuleFor(x => x.Ano)
                .InclusiveBetween(1500, DateTime.Now.Year)
                .WithMessage($"Ano deve estar entre 1500 e {DateTime.Now.Year}.");

            RuleFor(x => x.Edicao)
                .GreaterThan(0).WithMessage("Edição deve ser maior que 0.");

            RuleFor(x => x.NumeroDePaginas)
                .GreaterThan(0).WithMessage("Número de páginas deve ser maior que 0.");

            RuleFor(x => x.Descricao)
                .MaximumLength(1000).WithMessage("Descrição deve ter no máximo 1000 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descricao));

            RuleFor(x => x.SobreAutor)
                .MaximumLength(1000).WithMessage("Sobre o autor deve ter no máximo 1000 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.SobreAutor));

            RuleFor(x => x.Capa)
                .Must(file => file == null || file.ContentType.StartsWith("image/"))
                .WithMessage("Arquivo deve ser uma imagem.");

            RuleFor(x => x.Capa)
                .Must(file => file == null || file.Length <= 2 * 1024 * 1024)
                .WithMessage("Imagem deve ter no máximo 2MB.");
        }
    }
}