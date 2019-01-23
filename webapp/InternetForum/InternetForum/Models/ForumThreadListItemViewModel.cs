using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class ForumThreadListItemViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje Id příspěvku.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna příspěvků.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		public string Description { get; set; }

		public static ForumThreadListItemViewModel CreateFromEntity(ForumThread entity)
		{
			var model = new ForumThreadListItemViewModel();
			model.Id = entity.Id;
			model.Name = entity.Name;
			model.Description = entity.Description;

			return model;
		}
	}
}