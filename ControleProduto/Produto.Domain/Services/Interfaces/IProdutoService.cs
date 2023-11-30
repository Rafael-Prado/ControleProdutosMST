

using FluentValidation.Results;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ValidationResult> InserirProduto(Produto produto);
        Task<ValidationResult> UpdateProduto(int id,Produto produto);
        Task<bool> DeletarProduto(int idProduto);
        Task<List<Produto>> ListarProdutos();
        Task<List<Produto>> ListarProdutosPorCategoria(int IdCategoria);


    }
}
