using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetForum.DL.Entities
{
	public class Post : IEntity<int>
	{
		/// <summary>
		/// Vrací nebo nastavuje ID příspěvku.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl příspěvek vytvořen.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id vlákna, kterého je příspěvek součástí.
		/// </summary>
		[Required]
		public int ForumThreadId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		[Required]
		public virtual ForumThread ForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id autora.
		/// </summary>
		[Required]
		public string AuthorId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora příspěvku.
		/// </summary>
		[Required]
		public virtual ApplicationUser Author { get; set; }


		public static Post Create(string title, string body, DateTime createdAt, string authorId, int forumThreadId)
		{
			var post = new Post();
			post.Title = title;
			post.Body = body;
			post.CreatedAt = createdAt;
			post.AuthorId = authorId;
			post.ForumThreadId = forumThreadId;

			return post;
		}

		public static Post Create(int id, string title, string body, DateTime createdAt, string authorId,
			int forumThreadId, ICollection<Comment> comments)
		{
			var post = Create(title, body, createdAt, authorId, forumThreadId);
			post.Id = id;

			return post;
		}
	}
}