using Loja.Core.Models;
using LojaVirtual.API.Models;
using LojaVirtual.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.API.Services
{
    public interface IProdutoService
    {
        Task AdicionarProduto(Produto produto);
        Task AdicionarMarca(Marca marca);
        Task AdicionarTipoProduto(TipoProduto tipoProduto);
        Task AdicionarTamanho(Tamanho tamanho);
        Task<PagedResult<Produto>> ObterPorPagina(List<FiltroViewModel> filtros, int pageSize, int pageIndex, OrdenacaoViewModel ordenacao, string query = null);
    }
}
