using InternetForum.DL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly InternetForumDbContext dbContext;

		public Repository(InternetForumDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public TEntity GetById(params object[] id)
		{
			return this.dbContext.Set<TEntity>().Find(id);
		}

		public void Add(TEntity entity)
		{
			this.dbContext.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			this.dbContext.Set<TEntity>().AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			this.dbContext.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			this.dbContext.Set<TEntity>().RemoveRange(entities);
		}

		public TEntity FirstOrDefault()
		{
			return this.dbContext.Set<TEntity>().FirstOrDefault();
		}

		public virtual IQueryable<TEntity> GetAll()
		{

			IQueryable<TEntity> query = this.dbContext.Set<TEntity>();
			return query;
		}

		public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			IQueryable<TEntity> query = this.dbContext.Set<TEntity>().Where(predicate);
			return query;
		}

		public virtual void Update(TEntity entity)
		{
			this.dbContext.Set<TEntity>().Attach(entity);
			this.dbContext.Entry(entity).State = EntityState.Modified;
			this.dbContext.SaveChanges();
		}
	}
}