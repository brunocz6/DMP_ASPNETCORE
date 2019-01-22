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
		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[MaxLength(100)]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		[MaxLength(2000)]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		public int ForumThreadId { get; set; }

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