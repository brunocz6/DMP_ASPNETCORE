using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class PostViewModel
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
		/// Vrací nebo nastavuje odkaz autora příspěvku.
		/// </summary>
		public LinkViewModel AuthorLink { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje datum přidání příspěvku.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje odkaz na vlákno příspěvku.
		/// </summary>
		public LinkViewModel ForumThreadLink { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje komentáře příspěvku.
		/// </summary>
		public IEnumerable<CommentViewModel> Comments { get; set; }

		public static PostViewModel CreateFromEntity(Post post)
		{
			var model = new PostViewModel();
			model.Id = post.Id;
			model.Title = post.Title;
			model.Body = post.Body;
			model.AuthorLink = new LinkViewModel(post.AuthorId, post.Author.UserName);
			model.CreatedAt = post.CreatedAt;
			model.ForumThreadLink = new LinkViewModel(post.ForumThreadId, post.ForumThread.Name);
			model.Comments = post.Comments.Select(c => CommentViewModel.CreateFromEntity(c));

			return model;
		}
	}
}