using System.Linq.Expressions;
using Confitec.Domain.Entities.Base;
using Confitec.Domain.Interfaces.Repositories.Base;
using Confitec.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Infra.Data.Repositories.Base;

public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public Repository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Add(TEntity obj)
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    await ctx.AddAsync(obj);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    return await ctx.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<TEntity>> GetAll()
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    return await ctx.Set<TEntity>().ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    return await ctx.Set<TEntity>().Where(expression).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(TEntity obj)
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    ctx.Set<TEntity>().Update(obj);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(Guid id)
        {
             try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    var entity = await GetById(id);
                    ctx.Remove(entity!);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
