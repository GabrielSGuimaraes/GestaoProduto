using Domain.Dtos;
using Domain.Dtos.Fornecedor;
using GestaoProdutos;
using GestaoProdutos.Validators;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Http;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace GestaoProdutosTest
{
    [TestClass]
    public class ProdutoControllerTest
    {

        [Fact]
        public void Produto_OK()
        {
            var validator = new ProdutoValidator();
            ProdutoRequestDto testRequest = new ProdutoRequestDto { Id = 1, Descricao = "Produto Teste", DataFabricacao = System.DateTime.Now, DataValidade = System.DateTime.Now.AddDays(30),FornecedorId = 1  };
            //populate with dummy data
            var result = validator.Validate(testRequest);

            Assert.AreEqual(true, result.IsValid);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MustDescriptProduto(string descricao)
        {
            var validator = new ProdutoValidator();
            ProdutoRequestDto testRequest = new ProdutoRequestDto { Id = 1, Descricao = descricao, DataFabricacao = System.DateTime.Now, DataValidade = System.DateTime.Now.AddDays(30), FornecedorId = 1 };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            var expectErroMessage = "A descrição do produto é obrigatória";
            Assert.AreEqual(expectErroMessage, result.Errors[0].ErrorMessage);
        }        


        [Fact]        
        public void DataFabricacaoGreatherThanDataValidadeProduto()
        {
            var validator = new ProdutoValidator();
            ProdutoRequestDto testRequest = new ProdutoRequestDto { Id = 1, Descricao = "Produto Teste", DataFabricacao = System.DateTime.Now.AddDays(10), DataValidade = System.DateTime.Now, FornecedorId = 1 };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            var expectErroMessage = "A data de fabricação não pode ser maior ou igual a data de validade";
            Assert.AreEqual(expectErroMessage, result.Errors[0].ErrorMessage);
        }


        [Fact]
        public void DataFabricacaoEqualsDataValidadeProduto()
        {
            var validator = new ProdutoValidator();
            ProdutoRequestDto testRequest = new ProdutoRequestDto { Id = 1, Descricao = "Produto Teste", DataFabricacao = System.DateTime.Now, DataValidade = System.DateTime.Now, FornecedorId = 1 };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            var expectErroMessage = "A data de fabricação não pode ser maior ou igual a data de validade";
            Assert.AreEqual(expectErroMessage, result.Errors[0].ErrorMessage);
        }
    }
}
