using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.DL
{
	public static class DatabaseInitializer
	{
		public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, InternetForumDbContext dbContext)
		{
			// Vytvoření administračního účtu a uživatelských rolí.
			IdentityDataInitializer.SeedData(userManager, roleManager);

			// Vytvoření hlavního vlákna příspěvků.
			var mainForumThread = new ForumThread()
			{
				Name = "Hlavní vlákno",
				Description = "Toto je hlavní vlákno internetového fóra.",
				CreatedAt = DateTime.Now
			};

			var isMainThreadInDatabse = dbContext.ForumThreads.Any(ft => ft.Name == mainForumThread.Name);

			if (!isMainThreadInDatabse)
			{
				dbContext.Add(mainForumThread);
			}

			// Uložení změn do databáze.
			dbContext.SaveChanges();
		}
	}
}