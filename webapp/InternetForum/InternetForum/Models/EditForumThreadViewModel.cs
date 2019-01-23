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
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna příspěvků.
		/// </summary>
		[Display(Name = "Název")]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[Display(Name = "Popis")]
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