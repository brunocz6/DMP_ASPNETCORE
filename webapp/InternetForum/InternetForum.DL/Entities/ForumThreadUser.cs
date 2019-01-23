using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetForum.DL.Entities
{
	public class ForumThreadUser
	{
		public ForumThreadUser()
		{

		}

		public ForumThreadUser(string userId, int forumThreadId)
		{
			this.UserId = userId;
			this.ForumThreadId = forumThreadId;
		}

		/// <summary>
		/// Vrací nebo nastavuje Id vlákna.
		/// </summary>
		[Required]
		public int ForumThreadId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id uživatele.
		/// </summary>
		[Required]
		public string UserId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje vlákno.
		/// </summary>
		[Required]
		public virtual ForumThread ForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje uživatele.
		/// </summary>
		[Required]
		public virtual ApplicationUser User { get; set; }

		public static ForumThreadUser Create(int forumThreadId, string userId)
		{
			var forumThreadUser = new ForumThreadUser();
			forumThreadUser.ForumThreadId = forumThreadId;
			forumThreadUser.UserId = userId;

			return forumThreadUser;
		}
	}
}