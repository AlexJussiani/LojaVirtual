using Loja.Core.Data;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LojaVirtual.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get;  set; }        
        public bool Ativo { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorVenda { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; set; }
        public bool removido { get; set; }
        public Genero Genero { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public Marca Marca { get; set; }
        public Tamanho Tamanho { get; set; }
        public Cor Cor { get; set; }

        //EF Relation
        public IEnumerable<ImagemProduto> Imagens { get; set; }
        public Guid TipoProdutoId { get; set; }
        public Guid MarcaId { get; set; }
        public Guid CorId { get; set; }
        public Guid TamanhoId { get; set; }

        public void CalcularValorProduto()
        {
            if (TipoDesconto == 0)
            {
                ValorVenda = ValorTotal;
                return;
            }
            decimal desconto = 0;
            var valor = ValorTotal;

            if(((int)TipoDesconto) == 1)
            {
                desconto = (valor * ValorDesconto) / 100;
                valor -= desconto;
            }
            else
            {
                desconto = ValorDesconto;
                valor -= desconto;
            }

            ValorVenda = valor < 0 ? 0: valor;
            ValorDesconto = desconto;

        }
    }
}
