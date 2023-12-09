namespace Confitec.Application.Interfaces.Services.Base;

public interface IService<TEntity> where TEntity : class
{
    Task Add(TEntity viewModel);

    Task Update(TEntity viewModel);

    Task<TEntity?> GetById(Guid id);

    Task<IList<TEntity>> GetAll();

    Task Remove(Guid id);
}