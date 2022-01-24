using System.Threading.Tasks;

namespace Api.Cliente.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
