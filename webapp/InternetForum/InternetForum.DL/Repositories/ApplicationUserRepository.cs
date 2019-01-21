using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		public ApplicationUserRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}