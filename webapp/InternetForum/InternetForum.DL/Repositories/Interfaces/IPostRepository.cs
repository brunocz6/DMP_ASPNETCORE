using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories.Interfaces
{
	public interface IPostRepository : IRepository<Post>
	{
		/// <summary>
		/// Vrací všechny příspěvky daného uživatele.
		/// </summary>
		/// <param name="userId">Id uživatele (GUID)</param>
		IEnumerable<Post> GetUsersPosts(string userId, int page, int pageSize);

		/// <summary>
		/// Vrací nejnovější příspěvky v databázi.
		/// </summary>
		/// <param name="page">Číslo stránky</param>
		/// <param name="pageSize">Velikost stránky</param>
		/// <returns>Nejnovější příspěvky jako <see cref="IEnumerable{Post}"/></returns>
		IEnumerable<Post> GetMostRecentPosts(int page, int pageSize);
	}
}