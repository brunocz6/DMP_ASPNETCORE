using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CreateForumThreadViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		[Display(Name = "Název")]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[Display(Name = "Popis")]
		public string Description { get; set; }

		public ForumThread CreateEntity()
		{
			return ForumThread.Create(this.Name, DateTime.Now, this.Description);
		}
	}
}