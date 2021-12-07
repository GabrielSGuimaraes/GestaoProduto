using Domain.Dtos;
using Domain.Entities.FornecedorEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class Produto
    {

        private Produto() { }

        public static Produto Create(ProdutoRequestDto dto)
        {
            var produto = new Produto
            {
                Descricao = dto.Descricao,
                Situacao = true,
                DataFabricacao = dto.DataFabricacao,
                DataValidade = dto.DataValidade,
                FornecedorId = dto.FornecedorId

            };
            return produto;
        }
        
    }
}
