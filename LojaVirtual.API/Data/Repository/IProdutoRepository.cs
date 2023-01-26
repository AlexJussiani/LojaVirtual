﻿using Ci.Calcados.API.Models;
using Ci.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci.Calcados.API.Data.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //Produto
        Task<List<Produto>> ObterTodosProdutos();
        Task<Produto> ObterProdutoPorId(Guid id);
        void AdicionarProduto(Produto produto);
        void AtualizarProduto(Produto produto);

        //Marca
        Task<List<Marca>> ObterTodasMarcas();
        Task<Marca> ObterMarcaPorId(Guid id);
        void AdicionarMarca(Marca marca);
        void AtualizarMarca(Marca marca);

        //TipoProduto
        Task<List<TipoProduto>> ObterTodosTipoProduto();
        Task<TipoProduto> ObterTipoProdutoPorId(Guid id);
        void AdicionarTipoProduto(TipoProduto tipoProduto);
        void AtualizarTipoProduto(TipoProduto tipoProduto);

        //TipoCores
        Task<List<Cor>> ObterTodasCores();
        Task<Cor> ObterCorPorId(Guid id);
        void AdicionarCor(Cor cor);
        void AtualizarCor(Cor cor);

        //Tamanhos
        Task<List<Tamanho>> ObterTodosTamanhos();
        Task<Tamanho> ObterTamanhoPorId(Guid id);
        void AdicionarTamanho(Tamanho tamanho);
        void AtualizarTamanho(Tamanho tamanho);
    }
}
