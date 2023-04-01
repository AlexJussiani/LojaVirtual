using LojaVirtual.API.Models;
using System;
using System.Linq;
using Xunit;

namespace LojaVirtual.Tests
{
    public class ProdutosTests
    {

        [Fact(DisplayName = "Cadastrar Novo Produto Sem Desconto Válido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_SemDesconto_DeveEstarValido()
        {
            //Arrange Act
            var idProduto = Guid.NewGuid();
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(00001, "Camiseta", "Camiseta Polo Braca", true, 250, 0, TipoDesconto.SemDesconto, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //Assert
            Assert.Equal(250, produto.ValorVenda);
        }

        [Fact(DisplayName = "Cadastrar Novo Produto Inválido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_SemDesconto_DeveEstarInValido()
        {
            //Arrange 
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(0, "", "", true, 0, -1, TipoDesconto.SemDesconto, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //act
            var result = produto.Validar();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal(5, result.Errors.Count);
            Assert.Contains(ProdutoValidation.CodigoErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ProdutoValidation.NomeErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ProdutoValidation.DescricaoErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ProdutoValidation.ValorTotalErroMsg, result.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ProdutoValidation.ValorDescontoErroMsg, result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Cadastrar Novo Produto Desconto Valor Válido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_DescontoValor_DeveEstarValido()
        {
            //Arrange Act
            var idProduto = Guid.NewGuid();
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(00001, "Camiseta", "Camiseta Polo Braca", true, 250, 75, TipoDesconto.Valor, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //Assert
            Assert.Equal(175, produto.ValorVenda);
        }

        [Fact(DisplayName = "Cadastrar Novo Produto Desconto Valor Inválido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_DescontoValor_DeveEstarInvalido()
        {
            //Arrange
            var idProduto = Guid.NewGuid();
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(00001, "Camiseta", "Camiseta Polo Braca", true, 250, -300, TipoDesconto.Valor, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //act
            var result = produto.Validar();

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ProdutoValidation.ValorDescontoErroMsg, result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Cadastrar Novo Produto Desconto Porcentagem Válido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_DescontoProcentagem_DeveEstarValido()
        {
            //Arrange Act
            var idProduto = Guid.NewGuid();
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(00001, "Camiseta", "Camiseta Polo Braca", true, 250, 25, TipoDesconto.Porcentagem, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //Assert
            Assert.Equal((decimal)187.5, produto.ValorVenda);
        }

        [Fact(DisplayName = "Cadastrar Novo Produto Desconto Porcentagem Inválido")]
        [Trait("Categoria", "Produtos")]
        public void CadastrarProduto_DescontoVaPorcentagem_DeveEstarInvalido()
        {
            //Arrange
            var idProduto = Guid.NewGuid();
            var idTipoProduto = Guid.NewGuid();
            var idMarca = Guid.NewGuid();
            var idCor = Guid.NewGuid();
            var idTamanho = Guid.NewGuid();
            var produto = new Produto(00001, "Camiseta", "Camiseta Polo Braca", true, 250, -300, TipoDesconto.Porcentagem, "", false, Genero.Masculino, idTipoProduto, idMarca, idCor, idTamanho);

            //act
            var result = produto.Validar();

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ProdutoValidation.PorcentagemDescontoErroMsg, result.Errors.Select(e => e.ErrorMessage));
        }
    }
}
