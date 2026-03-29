using FluentValidation;
using Sistema_Biblioteca.Modules.Emprestimos.DTOs.Request;

namespace Sistema_Biblioteca.Modules.Emprestimos.Validators
{
    public class EmprestimoRequestDtoValidator : AbstractValidator<EmprestimoRequestDto>
    {
        public EmprestimoRequestDtoValidator()
        {

            RuleFor(x => x.LivroId)
                .GreaterThan(0).WithMessage("LivroId deve ser maior que zero.");

            RuleFor(x => x.DataEmprestimo)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Data de empréstimo não pode ser no futuro.");

            RuleFor(x => x.DataLimite)
                .GreaterThan(x => x.DataEmprestimo)
                .WithMessage("Data limite deve ser maior que a data de empréstimo.");

            RuleFor(x => x.DataLimite)
                .Must((dto, dataLimite) =>
                    (dataLimite - dto.DataEmprestimo).TotalDays <= 30)
                .WithMessage("O prazo máximo de empréstimo é de 30 dias.");

            RuleFor(x => x.DataDevolucao)
                .GreaterThanOrEqualTo(x => x.DataEmprestimo)
                .WithMessage("Data de devolução não pode ser antes da data de empréstimo.")
                .When(x => x.DataDevolucao.HasValue);
        }
    }
}