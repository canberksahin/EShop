using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ShopContext _dbcontext;

        public EfRepository(ShopContext context)
        {
            _dbcontext = context;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await(await ApplySpecification(specification)).ToListAsync();
        }

        private async Task<IQueryable<T>> ApplySpecification(ISpecification<T> specification)
        {
            return await EfSpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>().AsQueryable(), specification);
        }
    }
}
