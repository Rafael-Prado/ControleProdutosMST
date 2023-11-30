using Produtos.Domain.Entities;
using Produtos.Domain.Enuns;

namespace ProdutoApi.Model
{
    public class ProdutoModel
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Ativo Ativo { get; set; }
        public bool Perecivel { get; set; }
        public int CategoriaId { get; set; }
    }
}
