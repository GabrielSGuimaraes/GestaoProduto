using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProdutoRequestDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }      
        public DateTime DataValidade { get; set; }       
        public int FornecedorId { get; set; }
    }
}
