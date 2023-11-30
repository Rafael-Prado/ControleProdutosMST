
using FluentValidation;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Validador
{
    public  class CategoriaProdutoValidador : AbstractValidator<CategoriaProduto>
    {
        public CategoriaProdutoValidador()
        {
            RuleFor(categoria => categoria.Nome).NotNull().Empty().WithMessage(categoria => $" Nome não pode se vazia ou nulo!");
            RuleFor(categoria => categoria.Ativo).NotNull().WithMessage(categoria => $" Ativo não pode nulo!");
            RuleFor(categoria => categoria.Descricao).NotNull().WithMessage(categoria => $" Cadegoria não pode nulo!");
        }
    }
}
