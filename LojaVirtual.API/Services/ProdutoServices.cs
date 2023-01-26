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

        public async Task Adicionar(Produto produto)
        {
            produto.CalcularValorProduto();

            _produtoRepository.AdicionarProduto(produto);
            await PersistirDados(_produtoRepository.UnitOfWork);
        }
    }
}
