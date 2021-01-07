using Microsoft.EntityFrameworkCore;
using Sat.Core.Entities;
using Sat.Core.Interfaces;
using Sat.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(long id) => 
            await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() =>
            await _context.Set<T>().ToListAsync();

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification) =>
            await ApplySpecification(specification).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification) =>
            await ApplySpecification(specification).ToListAsync();

        public async Task<int> CountAsync(ISpecification<T> specification) =>
            await ApplySpecification(specification).CountAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) =>
            SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}
