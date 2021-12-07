using Domain.Dtos.Fornecedor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.FornecedorEntity
{
    public partial class Fornecedor
    {
        private Fornecedor() { }

        public static Fornecedor Create(FornecedorDto dto) {
            var fornecedor = new Fornecedor
            {                
                Descricao = dto.Descricao,
                CNPJ = dto.CNPJ
            };
            return fornecedor;
        }
    }
}
