using InternetForum.DL.Repositories;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly InternetForumDbContext dbContext;

		private readonly CommentRepository commentRepository;
		private readonly ForumThreadRepository forumThreadRepository;
		private readonly PostRepository postRepository;
		private readonly ApplicationUserRepository userRepository;

		public ICommentRepository CommentRepository => this.commentRepository;

		public IForumThreadRepository ForumThreadRepository => this.forumThreadRepository;

		public IPostRepository PostRepository => this.postRepository;

		public IApplicationUserRepository ApplicationUserRepository => this.userRepository;

		public UnitOfWork(InternetForumDbContext dbContext)
		{
			this.dbContext = dbContext;
			this.commentRepository = new CommentRepository(dbContext);
			this.forumThreadRepository = new ForumThreadRepository(dbContext);
			this.postRepository = new PostRepository(dbContext);
			this.userRepository = new ApplicationUserRepository(dbContext);
		}

		public void Dispose()
		{
			this.dbContext.Dispose();
		}

		/// <summary>
		/// Uloží změny do databáze a vrátí počet provedených změn.
		/// </summary>
		/// <returns>Počet provedených změn</returns>
		public int Save()
		{
			var result = this.dbContext.SaveChanges();
			return result;
		}
	}
}