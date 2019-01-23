using InternetForum.DL.Entities;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.DL.Repositories.Interfaces
{
	public interface IPostRepository : IRepository<Post>
	{
		/// <summary>
		/// Vrací všechny příspěvky daného uživatele.
		/// </summary>
		/// <param name="userId">Id uživatele (GUID)</param>
		IQueryable<Post> GetUsersPosts(string userId);


		/// <summary>
		/// Vrací všechny příspěvky daného uživatele.
		/// </summary>
		/// <param name="userId">Id uživatele (GUID)</param>
		IPagedList<Post> GetUsersPosts(string userId, int page, int pageSize);

		/// <summary>
		/// Vrací příspěvky v databázi patřící pod dané vlákno.
		/// </summary>
		/// <param name="forumThreadId">Id vlákna</param>
		/// <returns>Nejnovější příspěvky jako <see cref="IEnumerable{Post}"/></returns>
		IQueryable<Post> GetPostsByForumThreadId(int forumThreadId);

		/// <summary>
		/// Vrací příspěvky v databázi patřící pod dané vlákno.
		/// </summary>
		/// <param name="forumThreadId">Id vlákna</param>
		/// <param name="page">Číslo stránky</param>
		/// <param name="pageSize">Velikost stránky</param>
		/// <returns>Nejnovější příspěvky jako <see cref="IEnumerable{Post}"/></returns>
		IPagedList<Post> GetPostsByForumThreadId(int forumThreadId, int page, int pageSize);

		/// <summary>
		/// Vrací nejnovější příspěvky v databázi.
		/// </summary>
		/// <returns>Nejnovější příspěvky jako <see cref="IEnumerable{Post}"/></returns>
		IQueryable<Post> GetPostsOrderedByRecentality();

		/// <summary>
		/// Vrací nejnovější příspěvky v databázi.
		/// </summary>
		/// <param name="page">Číslo stránky</param>
		/// <param name="pageSize">Velikost stránky</param>
		/// <returns>Nejnovější příspěvky jako <see cref="IEnumerable{Post}"/></returns>
		IPagedList<Post> GetPostsOrderedByRecentality(int page, int pageSize);
	}
}