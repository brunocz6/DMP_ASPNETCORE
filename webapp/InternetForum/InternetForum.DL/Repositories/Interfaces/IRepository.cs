using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InternetForum.DL.Repositories.Interfaces
{
	/// <summary>
	/// Interface pro generický repozitář.
	/// </summary>
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Vloží do tabulky v databázi záznam entity
		/// </summary>
		void Add(TEntity entity);

		/// <summary>
		/// Vloží do tabulky v databázi pole záznamů entities
		/// </summary>
		void AddRange(IEnumerable<TEntity> entities);

		/// <summary>
		/// Vymaže z tabulky v databázi záznam entity
		/// </summary>
		void Remove(TEntity entity);

		/// <summary>
		/// Vymaže z tabulky v databázi pole záznamů entities
		/// </summary>
		void RemoveRange(IEnumerable<TEntity> entities);

		/// <summary>
		/// Aktualizuje záznam v databázi.
		/// </summary>
		void Update(TEntity entity);

		/// <summary>
		/// Vrací záznam z databáze s odpovídající id
		/// </summary>
		TEntity GetById(params object[] ids);

		/// <summary>
		/// Vrací první záznam z databáze nebo null.
		/// </summary>
		TEntity FirstOrDefault();

		/// <summary>
		/// Vrací záznamy odpovídající query.
		/// </summary>
		IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Vrací záznamy odpovídající dané query (s možností stránkování).
		/// </summary>
		/// <param name="pageNumber">Číslo stránky</param>
		/// <param name="pageSize">Velikost stránky</param>
		IPagedList<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);

		/// <summary>
		/// Vrátí query se záznamy.
		/// </summary>
		IQueryable<TEntity> GetAll();
	}
}