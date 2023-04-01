using FluentValidation;
using FluentValidation.Results;
using Loja.Core.Data;
using System;
using System.Collections.Generic;

namespace LojaVirtual.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {     

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }        
        public bool Ativo { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal ValorVenda { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public bool removido { get; private set; }
        public Genero Genero { get; private set; }
        public TipoDesconto TipoDesconto { get; private set; }
        public TipoProduto TipoProduto { get; private set; }
        public Marca Marca { get; private set; }
        public Tamanho Tamanho { get; private set; }
        public Cor Cor { get; private set; }

        //EF Relation
        public IEnumerable<ImagemProduto> Imagens { get; private set; }
        public Guid TipoProdutoId { get; private set; }
        public Guid MarcaId { get; private set; }
        public Guid CorId { get; private set; }
        public Guid TamanhoId { get; private set; }

        public Produto(int codigo, string nome, string descricao, bool ativo, decimal valorTotal, decimal valorDesconto, TipoDesconto tipoDesconto, string imagem, bool removido, Genero genero, Guid tipoProdutoId, Guid marcaId, Guid corId, Guid tamanhoId)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            ValorTotal = valorTotal;
            ValorDesconto = valorDesconto;
            TipoDesconto = tipoDesconto;
            Imagem = imagem;
            this.removido = removido;
            Genero = genero;
            TipoProdutoId = tipoProdutoId;
            MarcaId = marcaId;
            CorId = corId;
            TamanhoId = tamanhoId;
            CalcularValorProduto();
        }


        private void CalcularValorProduto()
        {
            if (TipoDesconto == TipoDesconto.SemDesconto)
            {
                ValorVenda = ValorTotal;
                return;
            }
            decimal desconto = 0;
            var valor = ValorTotal;

            if(TipoDesconto == TipoDesconto.Porcentagem)
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

        public ValidationResult Validar()
        {
            return new ProdutoValidation().Validate(this);
        }
    }

    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public static string CodigoErroMsg => "Produto sem código informado";

        public static string NomeErroMsg => "Produto sem nome informado";
        public static string DescricaoErroMsg => "Produto sem Descricao informado";

        public static string ValorTotalErroMsg => "Produto sem ValorTotal informado";

        public static string ValorDescontoErroMsg => "O Valor de desconto precisa ser igual ou superior a 0";
        public static string PorcentagemDescontoErroMsg => "A Porcentagem de desconto precisa ser entre 1 e 100%";

        public ProdutoValidation() 
        {
            RuleFor(p => p.Codigo)
                .NotNull()
                .WithMessage(CodigoErroMsg)
                .GreaterThan(0)
                .WithMessage(CodigoErroMsg);

            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage(NomeErroMsg);

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage(DescricaoErroMsg);

            RuleFor(p => p.ValorTotal)
                .NotNull()
                .WithMessage(ValorTotalErroMsg)
                .GreaterThan(0)
                .WithMessage(ValorTotalErroMsg);

            When(p => p.TipoDesconto.Equals(TipoDesconto.Valor), () =>
            {
                RuleFor(p => p.ValorDesconto)
                .NotNull()
                .WithMessage(ValorDescontoErroMsg)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ValorDescontoErroMsg);
            });

            When(p => p.TipoDesconto.Equals(TipoDesconto.Porcentagem), () =>
            {
                RuleFor(p => p.ValorDesconto)
                .NotNull()
                .ExclusiveBetween(1, 100)
                .WithMessage(PorcentagemDescontoErroMsg);
            });
        }
    }
}
