using System;
namespace PaktolusApp.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
		Task Add(TEntity entity);
		Task AddRange(IEnumerable<TEntity> entities);
		Task Update(TEntity entity);
		Task Delete(int id);
		Task DeleteRange(IEnumerable<TEntity> entities);
    }
}

