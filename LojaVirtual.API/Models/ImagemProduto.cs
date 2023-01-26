using Ci.Core.Data;
using System;
using System.Text.Json.Serialization;

namespace Ci.Calcados.API.Models
{
    public class ImagemProduto : Entity
    {
        public string Nome { get; set; }
        public bool removido { get; set; }
        //EF Relation
        public Guid ProdutoId { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }
    }
}
