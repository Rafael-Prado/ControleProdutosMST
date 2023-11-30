using Produtos.Domain.Entities;

namespace TestProduto
{
    public  class ProdutoModelBuilde
    {
        public Produto Build()
        {
            return new Produto()
            {
                Nome = "Teste Rafa",
                Descricao = "Teste Rafa",
                Perecivel = true,
                Ativo = Produtos.Domain.Enuns.Ativo.sim,
                CategoriaId = 1
            };
        }
        
    }
}
