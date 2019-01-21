using System;
using System.Collections.Generic;
using System.Linq;
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
		/// Vrátí query se všemi záznami.
		/// </summary>
		IQueryable<TEntity> GetAll();
	}
}