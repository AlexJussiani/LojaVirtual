using LojaVirtual.API.Models;
using System.Threading.Tasks;

namespace LojaVirtual.API.Services
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
    }
}
