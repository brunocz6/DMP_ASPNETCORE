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

		public IEnumerable<Post> GetMostRecentPosts(int page, int pageSize)
		{
			return this.dbContext.Posts.OrderByDescending(p => p.CreatedAt)
				.ToPagedList(page, pageSize);
		}

		public IEnumerable<Post> GetUsersPosts(string userId, int pageNumber = 1, int pageSize = 20)
		{
			return Find(p => p.Author.Id == userId, pageNumber, pageSize);
		}
	}
}