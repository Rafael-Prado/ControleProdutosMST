using Produtos.Domain.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Produtos.Domain.Entities
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Ativo Ativo { get; set; }
        public bool Perecivel { get; set; }
        public int CategoriaId { get; set; }
    }
}
