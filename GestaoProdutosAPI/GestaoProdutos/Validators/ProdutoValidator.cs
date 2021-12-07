using Data.Context;
using Domain.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoRequestDto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Descricao).NotNull().WithMessage("A descrição do produto é obrigatória")
                .NotEmpty().WithMessage("A descrição do produto é obrigatória");


            RuleFor(x => x.DataFabricacao.Date).NotNull().WithMessage("A data de fabricação é obrigatória")
                .NotEmpty().WithMessage("A data de fabricação é obrigatória")
                .Must(BeAValidDataFabricacao).WithMessage("A data de fabricação é obrigatória")
                .LessThan(x => x.DataValidade.Date).WithMessage("A data de fabricação não pode ser maior ou igual a data de validade");


            RuleFor(x => x.DataValidade).NotNull().WithMessage("A data de validade é obrigatória")
                .NotEmpty().WithMessage("A data de validade é obrigatória")
                .Must(BeAValidDataValidade).WithMessage("A data de validade é obrigatória");                
                
        }

        private bool BeAValidDataFabricacao(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool BeAValidDataValidade(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}
