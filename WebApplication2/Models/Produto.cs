using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? ImagemUrl { get; set; }

        public decimal Preco { get; set; }

        public string? Descricao { get; set; }

        public float Estoque { get; set; }

        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }
        
        [JsonIgnore]
        public required Categoria Categoria { get; set; }
    }
}
