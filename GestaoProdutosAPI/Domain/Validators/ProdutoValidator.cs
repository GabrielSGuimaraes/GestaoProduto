using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoRequestDto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("A descrição do produto é obrigatória");
            RuleFor(x => x.DataFabricacao).NotNull().NotEmpty().WithMessage("A data de fabricação é obrigatória")
                .Must(BeAValidDataFabricacao).WithMessage("A data de fabricação é obrigatória");
            RuleFor(x => x.DataValidade).NotNull().NotEmpty().WithMessage("A data de validade é obrigatória")
                .Must(BeAValidDataValidade).WithMessage("A data de validade é obrigatória")
                .GreaterThanOrEqualTo(x => x.DataFabricacao).WithMessage("A data de validade deve ser maior que a data de fabricação");                
                
        }

        private bool BeAValidDataFabricacao(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool BeAValidDataValidade(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool ValidFornecedor(int Id)
        {
            MyContext _db
        }





    }
}
