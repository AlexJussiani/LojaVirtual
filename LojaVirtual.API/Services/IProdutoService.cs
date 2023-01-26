using Ci.Calcados.API.Models;
using System.Threading.Tasks;

namespace Ci.Calcados.API.Services
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
    }
}
