using System.ComponentModel.DataAnnotations;
using System;
using LojaVirtual.API.Models;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LojaVirtual.API.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid TipoProdutoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid TamanhoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid MarcaId { get; set; }
        public int Codigo { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorDesconto { get; set; }
        public decimal ValorVenda { get; private set; }
        public string Imagem { get; set; }
        public bool removido { get; set; }
        public string ImagemUpload { get; set; }
        public Genero Genero { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
        [ScaffoldColumn(false)]
        public string NomeMarca { get; set; }
        [ScaffoldColumn(false)]
        public string NomeCor { get; set; }
        [ScaffoldColumn(false)]
        public string NomeTipoProduto { get; set; }
        [ScaffoldColumn(false)]
        public string NomeTamanho { get; set; }

        public IEnumerable<ImagemProdutoViewModel> Imagens { get; set; }
    }
}
