using System.Linq.Expressions;

namespace Confitec.Domain.Interfaces.Repositories.Base;

 public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);

        Task Update(TEntity obj);

        Task<TEntity?> GetById(Guid id);

        Task<IList<TEntity>> GetAll();        

        Task Remove(Guid id);
    }
