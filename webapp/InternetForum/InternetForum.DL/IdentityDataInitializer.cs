using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL
{
	public static class IdentityDataInitializer
	{
		public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			SeedRoles(roleManager);
			SeedUsers(userManager);
		}

		public static void SeedUsers(UserManager<ApplicationUser> userManager)
		{
			if (userManager.FindByNameAsync("Administrator").Result == null)
			{
				var user = new ApplicationUser();
				user.UserName = "bruno.pfohl@pslib.cz";
				user.Email = "bruno.pfohl@pslib.cz";

				IdentityResult result = userManager.CreateAsync(user, "Tajneheslo123!").Result;

				if (result.Succeeded)
				{
					userManager.AddToRoleAsync(user, "Administrator").Wait();
				}
			}
		}

		public static void SeedRoles(RoleManager<IdentityRole> roleManager)
		{
			if (!roleManager.RoleExistsAsync("NormalUser").Result)
			{
				var role = new IdentityRole("NormalUser");
				role.Name = "NormalUser";
				IdentityResult roleResult = roleManager.
				CreateAsync(role).Result;
			}

			if (!roleManager.RoleExistsAsync("Administrator").Result)
			{
				var role = new IdentityRole("Administrator");
				IdentityResult roleResult = roleManager.
				CreateAsync(role).Result;
			}
		}
	}
}