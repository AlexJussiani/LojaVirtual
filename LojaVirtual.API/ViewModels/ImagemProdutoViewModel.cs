using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.API.ViewModels
{
    public class ImagemProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool removido { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //EF Relation
        public Guid ProdutoId { get; set; }
    }
}
