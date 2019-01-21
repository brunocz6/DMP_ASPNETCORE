using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class PostRepository : Repository<Post>, IPostRepository
	{
		public PostRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}