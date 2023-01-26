using System.Threading.Tasks;

namespace Ci.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}