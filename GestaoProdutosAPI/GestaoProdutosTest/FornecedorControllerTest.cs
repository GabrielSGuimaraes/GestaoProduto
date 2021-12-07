using Domain.Dtos.Fornecedor;
using GestaoProdutos;
using GestaoProdutos.Validators;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GestaoProdutosTest
{
    [TestClass]
    public class FornecedorControllerTest

    { 
        [Fact]
        public void Fornecedor_OK()
        {
            var validator = new FornecedorValidator();
            FornecedorDto testRequest = new FornecedorDto { Id = 1, Descricao = "Teste", CNPJ = "00000000000000" };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            
            Assert.AreEqual(true, result.IsValid);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MustDescriptFornecedor(string descricao)
        {
            var validator = new FornecedorValidator();
            FornecedorDto testRequest = new FornecedorDto { Id = 1, Descricao = descricao, CNPJ = "00000000000000" };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            var expectErroMessage = "A descrição é obrigatória";
            Assert.AreEqual(expectErroMessage, result.Errors[0].ErrorMessage);            
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MustCNPJFornecedor(string CNPJ)
        {
            var validator = new FornecedorValidator();
            FornecedorDto testRequest = new FornecedorDto { Id = 1, Descricao = "Teste", CNPJ = CNPJ };
            //populate with dummy data
            var result = validator.Validate(testRequest);
            var expectErroMessage = "O CNPJ é obrigatório";
            Assert.AreEqual(expectErroMessage, result.Errors[0].ErrorMessage);
        }


        [Theory]
        [InlineData("0000000000")]
        [InlineData("000000000000000")]
        public void TestCNPJLenght(string CNPJ)
        {
            var validator = new FornecedorValidator();
            FornecedorDto testRequest = new FornecedorDto { Id = 1, Descricao = "Teste", CNPJ = CNPJ };
            //populate with dummy data
            var result = validator.Validate(testRequest);
           
            Assert.AreEqual(false, result.IsValid);
        }
    }
}
