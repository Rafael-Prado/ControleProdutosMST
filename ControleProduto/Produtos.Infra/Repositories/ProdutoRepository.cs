using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories.Interfaces;
using Produtos.Infra.Data;

namespace Produtos.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<bool> DeletarProduto(int idProduto)
        {
            var prod = _context.Produto.Where(p => p.Id == idProduto).FirstOrDefault();
            if (prod != null)
            {
                prod.Ativo = Domain.Enuns.Ativo.nao;
                _context.Update(prod);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            return await _context.Produto
                                 .ToListAsync();
        }

        public async Task<List<Produto>> ListarProdutosPorCategoria(int IdCategoria)
        {
            return await _context.Produto
                                 .Where(p => p.CategoriaId == IdCategoria)
                                 .ToListAsync();
        }

        public async Task<Produto> UpdateProduto(int id, Produto produto)
        {
            var prod = _context.Produto.Where(p => p.Id == id).FirstOrDefault();
            if (prod != null)
            {
                prod.Nome = produto.Nome;
                prod.Descricao = produto.Descricao;
                prod.Perecivel = produto.Perecivel;
                prod.CategoriaId = produto.CategoriaId;
                _context.Update(prod);
                _context.SaveChanges();
                return prod;
            }
            return null;
          
        }
    }
}
