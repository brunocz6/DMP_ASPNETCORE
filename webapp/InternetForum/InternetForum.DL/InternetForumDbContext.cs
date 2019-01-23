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
			modelBuilder.Entity<ForumThreadUser>()
				.HasKey(tu => new { tu.ForumThreadId, tu.UserId });

			modelBuilder.Entity<ForumThreadUser>()
				.HasOne(tu => tu.User)
				.WithMany(u => u.SubscribedForumThreads)
				.HasForeignKey(tu => tu.UserId);

			modelBuilder.Entity<ForumThreadUser>()
				.HasOne(tu => tu.ForumThread)
				.WithMany(t => t.Subscribers)
				.HasForeignKey(tu => tu.ForumThreadId);

			modelBuilder
				.Entity<Comment>()
					.HasOne(e => e.Author)
					.WithMany()
					.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<ForumThreadUser> ForumThreadUsers { get; set; }
		public DbSet<ForumThread> ForumThreads { get; set; }
	}
}