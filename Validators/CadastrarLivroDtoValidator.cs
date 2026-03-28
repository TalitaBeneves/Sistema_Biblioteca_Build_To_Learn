using FluentValidation;
using Sistema_Biblioteca.Controllers.Dtos;

namespace Sistema_Biblioteca.Validators
{
    public class CadastrarLivroDtoValidator : AbstractValidator<CadastrarLivroDto>
    {
        public CadastrarLivroDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do livro é obrigatório.")
                .MinimumLength(3).WithMessage("O nome do livro deve ter no mínimo 3 caracteres.")
                .MaximumLength(255).WithMessage("O nome do livro deve ter no máximo 255 caracteres.");
        }
    }
}
