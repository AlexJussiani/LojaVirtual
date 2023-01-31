using LojaVirtual.API.Data.Repository;
using LojaVirtual.API.Models;
using Loja.Core.Messages;
using System.Threading.Tasks;

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
    }
}
