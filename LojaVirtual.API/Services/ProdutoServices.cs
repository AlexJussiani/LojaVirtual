using LojaVirtual.API.Data.Repository;
using LojaVirtual.API.Models;
using Loja.Core.Messages;
using System.Threading.Tasks;
using Loja.Core.Models;
using LojaVirtual.API.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;
using Loja.MessageBus;
using EasyNetQ;
using Loja.Core.Messages.Integration;

namespace LojaVirtual.API.Services
{
    public class ProdutoServices : CommandHandler, IProdutoService
    {
        private readonly IMessageBus _bus;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoServices(IProdutoRepository produtoRepository, IMessageBus bus)
        {
            _bus = bus;
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            produto.Id = Guid.NewGuid();
           // produto.CalcularValorProduto();

           _produtoRepository.AdicionarProduto(produto);
            await PersistirDados(_produtoRepository.UnitOfWork);

           await  _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
                DateTime.Now,
                "Cadastro de um novo produto",
                2,
                1,
                null,
                null,
                produto.Id.ToString(),
                produto.Descricao
                ));
        }      

        public async Task AdicionarMarca(Marca marca)
        {
            marca.Id = Guid.NewGuid();
            _produtoRepository.AdicionarMarca(marca);           

            await PersistirDados(_produtoRepository.UnitOfWork);

            await _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
              DateTime.Now,
              "Cadastro de uma nova marca",
              2,
              3,
              null,
              null,
              marca.Id.ToString(),
              marca.Nome
              ));
        }

        public async Task AdicionarTipoProduto(TipoProduto tipoProduto)
        {
            tipoProduto.Id = Guid.NewGuid();
            _produtoRepository.AdicionarTipoProduto(tipoProduto);            

            await PersistirDados(_produtoRepository.UnitOfWork);

            await _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
               DateTime.Now,
               "Cadastro de uma nova marca",
               2,
               6,
               null,
               null,
               tipoProduto.Id.ToString(),
               tipoProduto.Nome
               ));
        }

        public async Task AdicionarTamanho(Tamanho tamanho)
        {
            tamanho.Id = Guid.NewGuid();
            _produtoRepository.AdicionarTamanho(tamanho);
            await PersistirDados(_produtoRepository.UnitOfWork);

            await _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
             DateTime.Now,
             "Cadastro de um novo Tamanho",
             2,
             5,
             null,
             null,
             tamanho.Id.ToString(),
             tamanho.Nome
             ));
        }

        public async Task<PagedResult<Produto>> ObterPorPagina(List<FiltroViewModel> filtros, int pageSize, int pageIndex, OrdenacaoViewModel ordenacao, string query = null)
        {
            
            List<Guid> corIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.COR).SelectMany(i => i.Ids).ToList();
            List<Guid> tipoProdutoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.TIPO_PRODUTO).SelectMany(i => i.Ids).ToList();
            List<Guid> tamanhoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.TAMANHO).SelectMany(i => i.Ids).ToList();
            List<Guid> marcaIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.MARCA).SelectMany(i => i.Ids).ToList();
            List<int> generoIds = filtros.Where(c => c.TipoFiltro == TipoFiltroViewModel.GENERO).SelectMany(i => i.GeneroIds).ToList();

            var produtos = (ordenacao == 0 ? await _produtoRepository.ObterTodosProdutosFiltradosOrderDefault(corIds, marcaIds, tamanhoIds, tipoProdutoIds, generoIds, pageSize, pageIndex, query) :
                            (int)ordenacao == 1 ? await _produtoRepository.ObterTodosProdutosFiltradosOrderValorCresc(corIds, marcaIds, tamanhoIds, tipoProdutoIds, generoIds, pageSize, pageIndex, query) :
                            await _produtoRepository.ObterTodosProdutosFiltradosOrderValorDesc(corIds, marcaIds, tamanhoIds, tipoProdutoIds, generoIds, pageSize, pageIndex, query)
                        );

            //Lançar evento de log
            publicarEvento();

            return new PagedResult<Produto>()
            {
                List = produtos,
                TotalResults = _produtoRepository.ObterTodosProdutos().Result.Count,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        private async void publicarEvento()
        {
            await _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
                DateTime.Now,
                "Acesso a listagem de produtos",
                1,
                1,
                null,
                null,
                null,
                null));

        }

        public async Task<Produto> ObterProdutoPorId(Guid idProduto)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(idProduto);

            if(produto == null)
                return null;
            await _bus.PublishAsync(new AdicionarEventoIntegrationEvent(
                DateTime.Now,
                "Acesso a um produto: " +produto.Descricao,
                1,
                1,
                null,
                null,
                produto.Id.ToString(),
                produto.Nome));

            return produto;
        }       
    }
}
