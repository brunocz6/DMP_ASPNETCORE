using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	/// <summary>
	/// ViewModel pro vytváření příspěvku.
	/// </summary>
	public class CreatePostViewModel
	{
		public CreatePostViewModel()
		{

		}

		public CreatePostViewModel(IEnumerable<ForumThread> forumThreads)
		{
			this.ForumThreads = forumThreads
				.Select(ft => new SelectListItem() {
					Text = ft.Name,
					Value = ft.Id.ToString()
				})
				.ToList();
		}

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[MinLength(1)]
		[Required]
		[MaxLength(255)]
		[Display(Name = "Nadpis")]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		[Required]
		[MinLength(1)]
		[Display(Name = "Obsah")]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		public int ForumThreadId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci dostupných vláken příspěvků.
		/// </summary>
		public IEnumerable<SelectListItem> ForumThreads { get; set; }

		/// <summary>
		/// Vrací nově vytvořenou entitu typu <see cref="Post"/> naplněnou daty z tohoto ViewModelu.
		/// </summary>
		/// <param name="entity">DB entita příspěvku</param>
		/// <returns>Příspěvek typu <see cref="Post"/></returns>
		public Post CreateEntity(string authorId)
		{
			return Post.Create(this.Title, this.Body, DateTime.Now, authorId, this.ForumThreadId);
		}
	}
}