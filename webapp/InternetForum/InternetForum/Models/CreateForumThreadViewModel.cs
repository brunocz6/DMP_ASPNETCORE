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
		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[Required]
		[MinLength(1)]
		[Display(Name = "Popis")]
		[MaxLength(1000)]
		public string Description { get; set; }

		public ForumThread CreateEntity()
		{
			return ForumThread.Create(this.Name, DateTime.Now, this.Description);
		}
	}
}