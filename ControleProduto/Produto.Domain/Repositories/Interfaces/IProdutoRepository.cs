using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> InserirProduto(Produto produto);
        Task<Produto> UpdateProduto(int id, Produto produto);
        Task<bool> DeletarProduto(int idProduto);
        Task<List<Produto>> ListarProdutos();
        Task<List<Produto>> ListarProdutosPorCategoria(int IdCategoria);

    }
}
