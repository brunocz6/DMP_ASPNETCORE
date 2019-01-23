using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class PostRepository : Repository<Post>, IPostRepository
	{
		public PostRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
	
		}

		public IQueryable<Post> GetPostsByForumThreadId(int forumThreadId)
		{
			return this.dbContext.Posts.OrderByDescending(p => p.CreatedAt)
				.Where(p => p.ForumThread.Id == forumThreadId);
		}

		public IQueryable<Post> GetUsersPosts(string userId)
		{
			return Find(p => p.Author.Id == userId);
		}

		public IQueryable<Post> GetPostsOrderedByRecentality()
		{
			return this.dbContext.Posts.OrderByDescending(p => p.CreatedAt);
		}

		public IPagedList<Post> GetPostsOrderedByRecentality(int page, int pageSize)
		{
			return GetPostsOrderedByRecentality().ToPagedList(page, pageSize);
		}

		public IPagedList<Post> GetPostsByForumThreadId(int forumThreadId, int page, int pageSize)
		{
			return GetPostsByForumThreadId(forumThreadId).ToPagedList(page, pageSize);
		}

		public IPagedList<Post> GetUsersPosts(string userId, int pageNumber = 1, int pageSize = 20)
		{
			return GetUsersPosts(userId).ToPagedList(pageNumber, pageSize);
		}
	}
}