using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class CommentRepository : Repository<Comment>, ICommentRepository
	{
		public CommentRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}