using Domain.Dtos.Fornecedor;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using FluentValidation;

namespace GestaoProdutos.Validators
{
    public class FornecedorValidator : AbstractValidator<FornecedorDto>
    {
        public FornecedorValidator()
        {
            RuleFor(x => x.Descricao).NotNull().WithMessage("A descrição é obrigatória")
                .NotEmpty().WithMessage("A descrição é obrigatória");

            RuleFor(x => x.CNPJ).NotNull().WithMessage("O CNPJ é obrigatório")
                .NotEmpty().WithMessage("O CNPJ é obrigatório")
                .MinimumLength(14).WithMessage("O CNPJ deve ter no minimo 14 caracteres")
                .MaximumLength(14).WithMessage("O CNPJ não deve ultrapassar os 14 caracteres");                
        }
    }
}
