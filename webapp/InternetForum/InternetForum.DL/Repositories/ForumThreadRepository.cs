using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class ForumThreadRepository : Repository<ForumThread>, IForumThreadRepository
	{
		public ForumThreadRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}