using Sat.Core.Entities;
using Sat.Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpecification(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
