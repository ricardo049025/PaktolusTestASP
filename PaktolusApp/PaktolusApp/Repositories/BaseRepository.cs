using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PaktolusApp.Interfaces;
using PaktolusApp.Models;

namespace PaktolusApp.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected DbTestContext context;

		public BaseRepository(DbTestContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await this.context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await this.context.Set<TEntity>().FindAsync(id);
		}

		public async Task Add(TEntity entity)
		{
			await this.context.Set<TEntity>().AddAsync(entity);
			await this.context.SaveChangesAsync();
		}

		public async Task AddRange(IEnumerable<TEntity> entities)
		{
			await this.context.Set<TEntity>().AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }

		public async Task Update(TEntity entity)
		{
            this.context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			await this.context.SaveChangesAsync();
        }

		public async Task Delete(int id)
		{
			var entity = await this.context.Set<TEntity>().FindAsync(id);
			this.context.Set<TEntity>().Remove(entity);
			await this.context.SaveChangesAsync();
		}

		public async Task DeleteRange(IEnumerable<TEntity> entities)
		{
			this.context.Set<TEntity>().RemoveRange(entities);
			await this.context.SaveChangesAsync();
		}
    }
}

