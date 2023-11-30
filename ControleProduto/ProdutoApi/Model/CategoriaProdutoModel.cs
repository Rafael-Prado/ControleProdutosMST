using Produtos.Domain.Entities;
using Produtos.Domain.Enuns;

namespace ProdutoApi.Model
{
    public class CategoriaProdutoModel
    {
        public bool Nome { get; set; }
        public string? Descricao { get; set; }
        public Ativo Ativo { get; set; }
        public virtual List<ProdutoModel> ProdutosModel { get; set; }
    }
}
