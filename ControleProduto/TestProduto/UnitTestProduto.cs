using Castle.Core.Resource;
using Moq;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories.Interfaces;
using Produtos.Domain.Services.Interfaces;
using Produtos.Domain.Validador;
using System.Collections.Generic;

namespace TestProduto
{
    [TestClass]
    public class UnitTestProduto
    {
        [TestMethod]
        public void Test_Produto_Deve_Ser_Valido()
        {
            //Arrange
            var produto = new ProdutoModelBuilde().Build();

            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Test_Produto_Nome_vazio()
        {
            //Arrange
            var produto = new ProdutoModelBuilde().Build();
            produto.Nome = "";

            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Nome não pode se vazia ou nulo!"));
        }

        [TestMethod]
        public void Test_Produto_Nome_null()
        {
            //Arrange
            var produto = new ProdutoModelBuilde().Build();
            produto.Nome = null;

            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(2, erros.Count);
            Assert.IsTrue(erros.Contains("Nome não pode se vazia ou nulo!"));
        }

        [TestMethod]
        public void Test_Produto_Ativo_Nao()
        {
            //Arrange
            var produto = new ProdutoModelBuilde().Build();
            produto.Ativo = Produtos.Domain.Enuns.Ativo.nao;

            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Ao cadastrar um produto novo o mesmo tem que estar ativo!"));
        }

        [TestMethod]
        public void Test_Produto_CategoriaId_Igual_0()
        {
            //Arrange
            var produto = new ProdutoModelBuilde().Build();
            produto.CategoriaId = 0;

            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Cadegoria não pode nulo ou igual a 0!"));
        }

        [TestMethod]
        public void Test_Get_Produto_Por_CategoriaId()
        {
            
            var categoriaId = 1;
            var produto = new List<Produto>() { new ProdutoModelBuilde().Build() };

            var repository = new Mock<IProdutoRepository>();
            repository.Setup(r => r.ListarProdutosPorCategoria(categoriaId))
                    .ReturnsAsync(produto);

            
            var listproduto = repository.Object.ListarProdutosPorCategoria(categoriaId);

            Assert.AreEqual(1, listproduto.Result.Count);
            repository.Verify(x => x.ListarProdutosPorCategoria(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void Test_Get_List_Produto()
        {
            
            var produto = new List<Produto>() { new ProdutoModelBuilde().Build() };

            var repository = new Mock<IProdutoRepository>();
            repository.Setup(r => r.ListarProdutos())
                    .ReturnsAsync(produto);

            
            var listproduto = repository.Object.ListarProdutos();

            Assert.AreEqual(1, listproduto.Result.Count);
            repository.Verify(x => x.ListarProdutos(), Times.Once);
        }

    }
}