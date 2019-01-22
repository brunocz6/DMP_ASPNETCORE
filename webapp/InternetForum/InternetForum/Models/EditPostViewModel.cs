using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	/// <summary>
	/// ViewModel pro editaci příspěvku.
	/// </summary>
	public class EditPostViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje Id příspěvku.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[MaxLength(100)]
		[Display(Name = "Nadpis")]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		[MaxLength(2000)]
		[Display(Name = "Obsah")]
		public string Body { get; set; }

		/// <summary>
		/// Vrací viewmodel typu <see cref="EditPostViewModel"/> vytvořený z DB entity.
		/// </summary>
		/// <param name="entity">DB entita příspěvku</param>
		public static EditPostViewModel CreateFromEntity(Post entity)
		{
			var model = new EditPostViewModel();
			model.Id = entity.Id;
			model.Title = entity.Title;
			model.Body = entity.Body;

			return model;
		}

		/// <summary>
		/// Naplní entitu datami z tohoto viewmodelu.
		/// </summary>
		/// <param name="entity">DB Entita</param>
		public void UpdateEntity(Post entity)
		{
			entity.Title = this.Title;
			entity.Body = this.Body;
		}
	}
}