using Domain.Dtos.Fornecedor;
using System;

namespace Domain.Dtos
{
    public class ProdutoResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }        
        public DateTime DataValidade { get; set; }       
        public FornecedorDto Fornecedor { get; set; }
    }
}
