using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class ForumThreadInfoViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje Id tohoto vlákna.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		public string Description { get; set; }

		public static ForumThreadInfoViewModel CreateFromEntity(ForumThread forumThread)
		{
			var model = new ForumThreadInfoViewModel();
			model.Id = forumThread.Id;
			model.Name = forumThread.Name;
			model.Description = forumThread.Description;

			return model;
		}
	}
}