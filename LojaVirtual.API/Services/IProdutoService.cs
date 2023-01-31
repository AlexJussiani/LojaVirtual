using LojaVirtual.API.Models;
using System.Threading.Tasks;

namespace LojaVirtual.API.Services
{
    public interface IProdutoService
    {
        Task AdicionarProduto(Produto produto);
        Task AdicionarMarca(Marca marca);
        Task AdicionarTipoProduto(TipoProduto tipoProduto);
        Task AdicionarTamanho(Tamanho tamanho);
    }
}
