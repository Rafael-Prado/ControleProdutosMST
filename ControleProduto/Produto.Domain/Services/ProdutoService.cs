using FluentValidation;
using FluentValidation.Results;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories.Interfaces;
using Produtos.Domain.Services.Interfaces;
using Produtos.Domain.Validador;
using System;

namespace Produtos.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private IValidator<Produto> _validator;

        public ProdutoService(IProdutoRepository repository, IValidator<Produto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> DeletarProduto(int idProduto)
        {
            return await _repository.DeletarProduto(idProduto);
        }

        public async Task<ValidationResult> InserirProduto(Produto produto)
        {
            ValidationResult result = await _validator.ValidateAsync(produto);

            if (!result.IsValid)
            {
                return result;
            }

            await _repository.InserirProduto(produto);
            return result;
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            return await _repository.ListarProdutos();
        }

        public async Task<List<Produto>> ListarProdutosPorCategoria(int IdCategoria)
        {
            return await _repository.ListarProdutosPorCategoria(IdCategoria);
        }

        public async Task<ValidationResult> UpdateProduto(int id, Produto produto)
        {
            var result = _validator.Validate(produto);

            if (!result.IsValid)
            {
                return result;
            }
            await _repository.UpdateProduto(id,produto);
            return result;
        }
    }
}
