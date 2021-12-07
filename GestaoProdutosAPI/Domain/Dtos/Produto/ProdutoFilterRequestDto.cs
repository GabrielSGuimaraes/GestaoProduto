using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Produto
{
    public class ProdutoFilterRequestDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public int FornecedorId { get; set; }
    }
}
