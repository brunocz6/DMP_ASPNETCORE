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
		public ApplicationUser()
		{

		}

		public ApplicationUser(string name, string email)
		{

		}

		public async Task<IdentityResult> GenerateUserIdentityAsync(AspNetUserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateAsync(this);
			// Add custom user claims here
			return userIdentity;
		}

		/// <summary>
		/// Vrací nebo nastavuje URL adresu profilového obrázku.
		/// </summary>
		public string AvatarURL { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci komentářů vytvořených tímto uživatelem.
		/// </summary>
		public virtual ICollection<Comment> Comments { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci příspevků tohoto uživatele.
		/// </summary>
		public virtual ICollection<Post> Posts { get; set; }
	}
}