using DotnetCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly EFDbContext _eFDbContext;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(EFDbContext eFDbContext)
        {
            _eFDbContext = eFDbContext;
            DbSet = _eFDbContext.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await Task.FromResult(DbSet);
            return result.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Func<TEntity, bool> predicate)
        {
            var result = await Task.FromResult(DbSet.Where(predicate));
            return result.ToList();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _eFDbContext.SaveChangesAsync();
        }
    }
}
