using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class ForumThreadInfoPanelViewModel
	{
		public ForumThreadInfoPanelViewModel()
		{

		}

		public ForumThreadInfoPanelViewModel(int id, string name, string description)
		{
			this.Id = id;
			this.Name = name;
			this.Description = description;
		}

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
	}
}