using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL
{
	public class InternetForumDbContext : IdentityDbContext<ApplicationUser>, IDisposable
	{
		public InternetForumDbContext(DbContextOptions<InternetForumDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
