using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CommentViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID komentáře.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah komentáře.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje jméno autora tohoto komentáře.
		/// </summary>
		public string AuthorUserName { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl tento komentář vytvořen.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		public static CommentViewModel CreateFromEntity(Comment comment)
		{
			var model = new CommentViewModel();
			model.Id = comment.Id;
			model.Body = comment.Body;
			model.AuthorUserName = comment.Author.UserName;
			model.CreatedAt = comment.CreatedAt;

			return model;
		}
	}
}