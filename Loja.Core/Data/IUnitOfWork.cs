using System.Threading.Tasks;

namespace Loja.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}