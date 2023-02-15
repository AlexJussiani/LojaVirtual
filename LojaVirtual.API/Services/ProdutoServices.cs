using LojaVirtual.API.Data.Repository;
using LojaVirtual.API.Models;
using Loja.Core.Messages;
using System.Threading.Tasks;
using Loja.Core.Models;
using LojaVirtual.API.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LojaVirtual.API.Services
{
    public class ProdutoServices : CommandHandler, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            produto.CalcularValorProduto();

            _produtoRepository.AdicionarProduto(produto);
            await PersistirDados(_produtoRepository.UnitOfWork);
        }      

        public async Task AdicionarMarca(Marca marca)
        {
            _produtoRepository.AdicionarMarca(marca);
            await PersistirDados(_produtoRepository.UnitOfWork);
        }

        public async Task AdicionarTipoProduto(TipoProduto tipoProduto)
        {
            _produtoRepository.AdicionarTipoProduto(tipoProduto);
            await PersistirDados(_produtoRepository.UnitOfWork);
        }

        public async Task AdicionarTamanho(Tamanho tamanho)
        {
            _produtoRepository.AdicionarTamanho(tamanho);
            await PersistirDados(_produtoRepository.UnitOfWork);
        }

        public async Task<PagedResult<Produto>> ObterPorPagina(List<FiltroViewModel> filtros, int pageSize, int pageIndex, string query = null)
        {
            List<Guid> corIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.COR).SelectMany(i => i.Ids).ToList();
            List<Guid> tipoProdutoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.TIPO_PRODUTO).SelectMany(i => i.Ids).ToList();
            List<Guid> tamanhoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.TAMANHO).SelectMany(i => i.Ids).ToList();
            List<Guid> marcaIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.MARCA).SelectMany(i => i.Ids).ToList();
            List<int> generoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.GENERO).SelectMany(i => i.GeneroIds).ToList();

            var produtos = await _produtoRepository.ObterTodosProdutosFiltrados(corIds, marcaIds, tamanhoIds, tipoProdutoIds, generoIds, pageSize, pageIndex, query);
            return new PagedResult<Produto>()
            {
                List = produtos,
                TotalResults = _produtoRepository.ObterTodosProdutos().Result.Count,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }
    }
}
