using Domain.Entities.FornecedorEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class Produto : BaseEntity
    {
        public string Descricao { get; private set; }
        public bool Situacao { get; private set; }
        public DateTime? DataFabricacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }


        public void SetDescricao(string value)
        {
            Descricao = value;
        }

        public void SetSituacao(bool value)
        {
            Situacao = value;
        }

        public void SetDataFabricacao(DateTime value)
        {
            DataFabricacao = value;
        }

        public void SetDataValidade(DateTime value)
        {
            DataValidade = value;
        }

        public void SetFornecedor(int value)
        {
            FornecedorId = value;
        }
    }
}
