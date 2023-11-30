using FluentValidation;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Validador
{
    public  class ProdutoValidador : AbstractValidator<Produto>
    {
        public ProdutoValidador()
        {
            RuleFor(produto => produto.Nome).NotNull().NotEmpty().WithMessage(produto => $"Nome não pode se vazia ou nulo!");
            RuleFor(produto => produto.Ativo ).NotEqual(Enuns.Ativo.nao).WithMessage(produto => $"Ao cadastrar um produto novo o mesmo tem que estar ativo!");
            RuleFor(produto => produto.CategoriaId).NotEqual(0).WithMessage(produto => $"Cadegoria não pode nulo ou igual a 0!");
        }
    }
}
