using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Fornecedor
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
    }
}
