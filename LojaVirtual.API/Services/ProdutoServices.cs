using Ci.Calcados.API.Data.Repository;
using Ci.Calcados.API.Models;
using Ci.Core.Messages;
using System.Threading.Tasks;

namespace Ci.Calcados.API.Services
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
