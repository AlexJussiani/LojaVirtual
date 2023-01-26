using Ci.Core.Data;
using System.Collections.Generic;

namespace Ci.Calcados.API.Models
{
    public class Marca : Entity
    {
        public string Nome { get; set; }
        public bool removido { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
