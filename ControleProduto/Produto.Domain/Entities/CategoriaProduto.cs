using Produtos.Domain.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produtos.Domain.Entities
{
    public class CategoriaProduto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Ativo Ativo { get; set; }
        public virtual List<Produto> Produtos { get; set; }

    }
}
