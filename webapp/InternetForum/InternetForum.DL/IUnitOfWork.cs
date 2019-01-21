using System;
using System.Collections.Generic;
using System.Text;
using InternetForum.DL.Repositories.Interfaces;

namespace InternetForum.DL
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Vrací repository pro tabulku Comments.
		/// </summary>
		ICommentRepository CommentRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku ForumThreads.
		/// </summary>
		IForumThreadRepository ForumThreadRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku Posts.
		/// </summary>
		IPostRepository PostRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku Users.
		/// </summary>
		IApplicationUserRepository ApplicationUserRepository { get; }

		/// <summary>
		/// Uloží změny do databáze.
		/// </summary>
		int Save();
	}
}