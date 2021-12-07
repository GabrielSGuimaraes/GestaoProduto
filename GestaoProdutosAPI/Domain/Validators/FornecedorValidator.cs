using Domain.Dtos.Fornecedor;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using FluentValidation;

namespace Domain.Validators
{
    public class FornecedorValidator : AbstractValidator<FornecedorDto>
    {
        public FornecedorValidator()
        {
            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("A descrição é obrigatória");
            RuleFor(x => x.CNPJ).NotNull().NotEmpty().WithMessage("O CNPJ é obrigatório")
                .MinimumLength(14).WithMessage("O CNPJ deve ter no minimo 14 caracteres")
                .MaximumLength(14).WithMessage("O CNPJ não deve ultrapassar os 14 caracteres");                
        }
    }
}
