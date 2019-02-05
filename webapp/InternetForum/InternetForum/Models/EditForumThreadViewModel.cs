using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class EditForumThreadViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje Id příspěvku.
		/// </summary>
		[Required]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna příspěvků.
		/// </summary>
		[MinLength(1)]
		[Display(Name = "Název")]
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[MinLength(1)]
		[Display(Name = "Popis")]
		[Required]
		[MaxLength(1000)]
		public string Description { get; set; }

		public static EditForumThreadViewModel CreateFromEntity(ForumThread entity)
		{
			var model = new EditForumThreadViewModel();
			model.Id = entity.Id;
			model.Name = entity.Name;
			model.Description = entity.Description;

			return model;
		}

		public void UpdateEntity(ForumThread entity)
		{
			entity.Name = this.Name;
			entity.Description = this.Description;
		}
	}
}