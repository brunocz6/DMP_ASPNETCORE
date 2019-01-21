using InternetForum.DL.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetForum.DL.Entities
{
	public class ApplicationUser : IdentityUser, IEntity<string>
	{
		public async Task<IdentityResult> GenerateUserIdentityAsync(AspNetUserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateAsync(this);
			// Add custom user claims here
			return userIdentity;
		}
	}
}