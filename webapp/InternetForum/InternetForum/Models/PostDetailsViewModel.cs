using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class PostDetailsViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID příspěvku.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje datum přidání příspěvku.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje viewmodel odkazu na vlákno příspěvku.
		/// </summary>
		public LinkViewModel ForumThreadLink { get; set; }

		/// <summary>
		/// Vrací viewmodel typu <see cref="PostDetailsViewModel"/> vytvořený z DB entity.
		/// </summary>
		/// <param name="entity">DB entita příspěvku</param>
		public static PostDetailsViewModel CreateFromEntity(Post post)
		{
			var model = new PostDetailsViewModel();
			model.Id = post.Id;
			model.Title = post.Title;
			model.Body = post.Body;
			model.CreatedAt = post.CreatedAt;

			model.ForumThreadLink = new LinkViewModel(post.ForumThreadId, post.ForumThread.Name);

			return model;
		}
	}
}