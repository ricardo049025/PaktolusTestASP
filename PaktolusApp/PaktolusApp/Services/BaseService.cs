using System;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PaktolusApp.Interfaces;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Repositories;

namespace PaktolusApp.Services
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
        protected IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
		{
            this.repository = repository;
        }

        public Task<IEnumerable<TEntity>> GetAll()
		{
			return this.repository.GetAll();
		}

		public Task<TEntity> GetById(int id)
		{
			return this.repository.GetById(id);
		}

		public Task Add(TEntity entity)
		{
			return this.repository.Add(entity);
		}

		public Task AddRange(IEnumerable<TEntity> entities)
		{
			return this.repository.AddRange(entities);
		}

		public Task Update(TEntity entity)
		{
			return this.repository.Update(entity);
		}

		public Task Delete(int id)
		{
			return this.repository.Delete(id);
		}

		public Task DeleteRange(IEnumerable<TEntity> entities)
		{
			return this.repository.DeleteRange(entities);
		}
	}
}

